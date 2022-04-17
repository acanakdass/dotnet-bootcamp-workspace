﻿
using DapperCrudAPIProject.API.Commands.UserUpdate;
using DapperCrudAPIProject.Business.Commands.UserDelete;
using DapperCrudAPIProject.Business.Commands.UserInsert;
using DapperCrudAPIProject.Business.Filters;
using DapperCrudAPIProject.Business.ObserverDP.Notifications.NotificationHandlers;
using DapperCrudAPIProject.Business.ObserverDP.Subjects;
using DapperCrudAPIProject.Business.Queries;
using DapperCrudAPIProject.Business.Queries.GetAll;
using DapperCrudAPIProject.Business.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DapperCrudAPIProject.Controllers
{
    public class  UsersController : CustomControllerBase
    {
        private readonly IMediator _mediator;
        private readonly INotificationSubject _subject;
        public UsersController(IMediator mediator, INotificationSubject subject)
        {
            _mediator = mediator;
            _subject = subject;
        }
        [HttpGet]
        //[CustomExceptionFilter]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new UserGetAllQuery());
            
            _subject.Notify();
            
            return CreateActionResult(result);
        }
        [HttpGet("pages/{page}/{pageSize}")]
        public async Task<IActionResult> GetAllWithPage(int page,int pageSize)
        {
            var result = await _mediator.Send(new UserWithPageQuery(){Page = page,PageSize = pageSize});
            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserInsertCommand command)
        {
            var result = await _mediator.Send(command);
            
            //Observer DP
            _subject.Attach(new UserCreatedSendSmsNotificationHandler());
            _subject.Attach(new UserCreatedSendEmailNotificationHandler());
            _subject.Notify();
            
            
            return CreateActionResult(result);
        }
        [ServiceFilter(typeof(UserNotFoundFilter))]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UserUpdateCommand command)
        {
            var result = await _mediator.Send(command);
            return CreateActionResult(result);
        }
        [ServiceFilter(typeof(UserNotFoundFilter))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        { 
            var result = await _mediator.Send(new UserDeleteCommand(){Id = id});
            return CreateActionResult(result);
        }
        [ServiceFilter(typeof(UserNotFoundFilter))]
        [HttpGet("{id}")]
        //[CustomExceptionFilter]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new UserGetByIdQuery(){Id = id});
            
            return CreateActionResult(result);
        }
    }
}
