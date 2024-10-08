﻿using AutoMapper;
using Gymphony.Application.Courses.Models.Dtos;
using Gymphony.Application.Courses.Queries;
using Gymphony.Domain.Common.Queries;
using Gymphony.Domain.Enums;
using Gymphony.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication;

namespace Gymphony.Infrastructure.Courses.QueryHandlers;

public class GetCourseSchedulesQueryHandler(IMapper mapper,
    ICourseRepository courseRepository, 
    ICourseScheduleRepository courseScheduleRepository) 
    : IQueryHandler<GetCourseSchedulesQuery, IEnumerable<CourseScheduleDto>>
{
    public async Task<IEnumerable<CourseScheduleDto>> Handle(GetCourseSchedulesQuery request, CancellationToken cancellationToken)
    {
        var foundCourse = await courseRepository.Get(course => course.Id == request.CourseId)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new ArgumentException($"Course with id {request.CourseId} does not exist!");

        if (request.IsActiveOnly && foundCourse.Status != ContentStatus.Activated)
            throw new AuthenticationException("Unauthorized Access!");

        var schedules = courseScheduleRepository.Get(schedule => schedule.CourseId == request.CourseId)
            .Include(schedule => schedule.Instructors!)
            .ThenInclude(i => i.ProfileImage)
            .ThenInclude(pi => pi.StorageFile)
            .Include(schedule => schedule.Enrollments)
            .Include(schedule => schedule.PendingEnrollments)
            .Select(schedule => new
            {
                Schedule = schedule,
                Enrollments = schedule.Enrollments == null ? 0 : schedule.Enrollments.Count,
                PendingEnrollments = schedule.PendingEnrollments == null ? 0 : schedule.PendingEnrollments.Count,
                AllowedEnrollments = foundCourse.Capacity
            })
            .AsEnumerable() 
            .Select(result => (
                Schedule: result.Schedule,
                Enrollments: result.Enrollments,
                IsAvailable: (result.Enrollments + result.PendingEnrollments) < result.AllowedEnrollments
            ));

        if (request.IsActiveOnly)
        {
            schedules = schedules.Where(schedule => schedule.IsAvailable);
        }

        return mapper.Map<IEnumerable<CourseScheduleDto>>(schedules);
    }
}
