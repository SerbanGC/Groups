using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace Controller
{
    [ApiController]
    [Route("/api/[controller]")]
    public class GroupController : ControllerBase
    {

        private readonly GroupService service;

        public GroupController(GroupService service)
        {
            this.service = service;
        }


        [HttpGet("{id}")]
        public ActionResult<List<Group>> GetGroup([FromRoute(Name = "id")] int groupId)
        {
            return service.GetGroupById(groupId);
        }

        [HttpPost]
        public Group Add([FromBody] Group group)
        {
            service.AddGroup(group);
            return group;
        }

        [HttpPut]
        public void UpdateGroupItemById([FromQuery] int groupId, [FromQuery] int itemId, [FromBody] GroupRequest group)
        {
            service.UpdateGroupItemByItemId(groupId, itemId, group);
        }

        [HttpDelete]
        public void DeleteGroupById([FromQuery] int groupId, [FromQuery] int itemId)
        {
            service.DeleteGroupById(groupId, itemId);
        }


        [HttpGet("{first-group}/{second-group}")]
        public List<Group> Combine([FromRoute(Name = "first-group")] int group1, [FromRoute(Name = "second-group")] int group2)
        {
            return service.Clone(group1, group2);
        }
    }
}