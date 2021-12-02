﻿using DataAccess;
using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _repository;
        private readonly MySqlContext _context;

        public UserController(ILogger<UserController> logger,MySqlContext context)
        {
            _logger = logger;
            _context = context;
            _repository = new UserRepository(_context);
        }

        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            var users = _repository.GetAll();
            return users;
        }

        [HttpGet]
        [Route("{id}")]
        public User GetUser(int id)
        {
            var user = _repository.GetById(id);
            return user;
        }

        [HttpGet]
        [Route("query")]
        public IEnumerable<User> GetByQuery()
        {
            var user = _context.User.FromSqlRaw($"select * from user where id in(1,2)");
            return user;
        }

        [HttpGet]
        [Route("name/{name}")]
        public User GetUserByName(String name)
        {
            Expression<Func<User, bool>> express = a => a.name == name;
            var user = _repository.GetByCondition(express);
            return user.FirstOrDefault();
        }

        [HttpGet]
        [Route("update")]
        public bool UpdateUser()
        {
            var user = _repository.GetById(3);
            user.name = "懒羊羊";
            return _repository.Update(user);
        }

        [HttpGet]
        [Route("insert")]
        public bool InsertUser()
        {
            var user = new User();
            user.name = "test";
            user.sex = "male";
            user.password = "123";
            user.age = 100;
            return _repository.Insert(user);
        }

        [HttpGet]
        [Route("delete")]
        public bool DeleteUser()
        {
            var user = _repository.GetById(9);
            return _repository.Delete(user);
        }

    }
}