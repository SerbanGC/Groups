using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using System.Threading.Tasks;
using Exceptions;

namespace Service
{
    public class GroupService
    {
        private readonly DbContext db;

        public GroupService(DbContext dbContext)
        {
            db = dbContext;
        }


        public List<Group> GetGroupById(int id)
        {
            if (db.groups.TryGetValue(id.ToString(), out List<Group> grouplist))
            {
                return grouplist;
            }

            throw new GroupException($"Group with id {id} not found!");
        }

        public void AddGroup(Group newGroup)
        {
            if (db.groups.TryGetValue(newGroup.groupNumber.ToString(), out List<Group> group))
            {
                if (CheckIfAlreadyExists(group, newGroup))
                {
                    throw new GroupException($"Group with id {newGroup.identifierInGroup} already exists!");
                }
                group.Add(newGroup);
            }
            else
            {
                db.groups.Add(newGroup.groupNumber.ToString(), new List<Group> { newGroup });
            }
        }


        public void DeleteGroupById(int groupId, int itemId)
        {
            if (db.groups.TryGetValue(groupId.ToString(), out var groupList))
            {
                var groupToDelete = groupList.FirstOrDefault(item => item.identifierInGroup == itemId);
                if (groupToDelete != null)
                {
                    groupList.Remove(groupToDelete);
                }
            }
            else
            {
                throw new GroupException($"No Group item with id {itemId} found inside group {groupId}");
            }
        }

        public void UpdateGroupItemByItemId(int groupId, int itemId, GroupRequest newGroup)
        {
            if (db.groups.TryGetValue(groupId.ToString(), out var group))
            {
                int index = group.FindIndex(item => item.identifierInGroup == itemId);
                if (index != -1)
                {
                    group[index].prop1 = newGroup.prop1;
                    group[index].prop2 = newGroup.prop2;
                    group[index].prop3 = newGroup.prop3;
                }
                else
                {
                    throw new GroupException($"Group item with id {itemId} not present!");
                }
            }
            else
            {
                throw new GroupException($"Group with id {groupId} not found!");
            }
        }

        private bool CheckIfAlreadyExists(List<Group> group, Group newGroup)
        {
            Group existItemWithId = group.Find(item => item.identifierInGroup == newGroup.identifierInGroup);
            if (existItemWithId != null)
            {
                return true;
            }
            return false;
        }

        public List<Group> Clone(int group1, int group2)
        {
            db.groups.TryGetValue(group1.ToString(), out var groupList1);
            db.groups.TryGetValue(group2.ToString(), out var groupList2);

            if (groupList1 != null && groupList2 != null)
            {
                groupList1.ForEach(item => item.groupNumber = group2);
                return groupList1;
            }
            return new List<Group>();
        }
    }
}