using Hapy.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hapy.Models;
using CommonLibrary;

namespace Hapy.MiddelLayer
{
    public class Users : DbCommands<UsersInfo>, IUsers
    {
        Dictionary<string, FilterCondition> filter;
        private DbCommands<UsersInfo> _dbCommands { get; set; }
        public Users()
        {
            filter = new Dictionary<string, FilterCondition>();
            _dbCommands = new DbCommands<UsersInfo>();
        }

        public ActionReturn Insert(UserInfo userInfo)
        {
            filter.Add("uprimarynumber", new FilterCondition()
            {
                Condition = Condition.AndAlso,
                Operation = CommonLibrary.Operation.EqualTo,
                Value = userInfo.Primarynumber.ToString()
            });
            filter.Add("uprimarynumbercode", new FilterCondition()
            {
                Condition = Condition.AndAlso,
                Operation = CommonLibrary.Operation.EqualTo,
                Value = userInfo.Primarynumbercode.ToString()
            });
            filter.Add("isactive", new FilterCondition()
            {
                Condition = Condition.AndAlso,
                Operation = CommonLibrary.Operation.EqualTo,
                Value = "true"
            });
            UsersInfo users = _dbCommands.FetchRecords<UsersInfo>(new Filter()
            {
                FilterOn = filter
            }).SingleOrDefault();
            if (users != null)
            {
                return new ActionReturn()
                {
                    Id = users.UId,
                    Status = users.UStatus
                };
            }
            users = Assgin(userInfo);
            _dbCommands.Insert(users);
            bool status = _dbCommands.Save();
            return new ActionReturn() { Id = users.UId, Status = status };
        }

        public IEnumerable<UserInfo> GetUserInfo(SearchParams search)
        {
            List<UserInfo> userInfo = new List<UserInfo>();
            _dbCommands.FetchRecords<UsersInfo>(new Filter() { FilterOn = search.FilterOn }).ToList().ForEach(x => { userInfo.Add(GetUserInfo(x)); });
            return userInfo;
        }

        public IEnumerable<UserInfo> GetUserInfoOnCloumns(SearchParams search)
        {
            List<UserInfo> userInfo = new List<UserInfo>();
            _dbCommands.FetchSelectRecords<UsersInfo>(new Filter() { FilterOn = search.FilterOn }).ToList().ForEach(x => { userInfo.Add(GetUserInfo(x)); });
            return userInfo;
        }

        public IEnumerable<Models.UserCompDetail> GetUserComp(SearchParams search)
        {
            List<Models.UserCompDetail> userComp = new List<Models.UserCompDetail>();
            _dbCommands.FetchRecords<DB.UserCompDetail>(new Filter() { FilterOn = search.FilterOn }).ToList().ForEach(x => userComp.Add(GetUserCompDetail(x)));
            return userComp;
        }

        private UsersInfo AssginUpdate(UserInfo userInfo)
        {
            return new UsersInfo()
            {
                UId = userInfo.UId,
                UName = userInfo.Name,
                ULName = userInfo.LName,
                UFname = userInfo.Fname,
                UDOB = userInfo.DOB,
                UPrimarynumber = userInfo.Primarynumber,
                UPrimarynumbercode = userInfo.Primarynumbercode,
                UEmailid = userInfo.Emailid,
                UGender = userInfo.Gender,
                USecondarycode = userInfo.Secondarycode,
                USecondarynumber = userInfo.Secondarynumber,
                UStatus = userInfo.Status,
                IsActive = userInfo.IsActive
            };
        }

        private UsersInfo Assgin(UserInfo userInfo)
        {
            return new UsersInfo()
            {
                UId = userInfo.UId,
                UName = userInfo.Name,
                ULName = userInfo.LName,
                UFname = userInfo.Fname,
                UDOB = userInfo.DOB,
                UAbout = userInfo.About,
                UPrimarynumber = userInfo.Primarynumber,
                UPrimarynumbercode = userInfo.Primarynumbercode,
                UEmailid = userInfo.Emailid,
                UDesc = userInfo.Desc,
                UProfileimage = userInfo.Profileimage,
                UWallimage = userInfo.Wallimage,
                UGender = userInfo.Gender,
                USecondarycode = userInfo.Secondarycode,
                USecondarynumber = userInfo.Secondarynumber,
                UStatus = userInfo.Status,
                IsActive = userInfo.IsActive
            };
        }

        public bool Update(UserAbout about)
        {
            DB.UsersInfo info = _dbCommands.FetchSingleRecord<UsersInfo>(about.UId);
            info.UAbout = about.About;
            info.UDesc = about.Desc;
            _dbCommands.ActionState(info, System.Data.Entity.EntityState.Modified);
            return _dbCommands.Save();
        }

        public bool Update(UserImage image)
        {
            UsersInfo usersInfo = _dbCommands.FetchSingleRecord<UsersInfo>(image.UId);
            if (image.Wallimage != null)
            {
                usersInfo.UWallimage = image.Wallimage;
            }
            else if (image.Profileimage != null)
            {
                usersInfo.UProfileimage = image.Profileimage;
            }
            _dbCommands.ActionState(usersInfo, System.Data.Entity.EntityState.Modified);
            return _dbCommands.Save();
        }

        public bool Update(UserInfo userInfo)
        {
            UsersInfo usersInfo = _dbCommands.FetchSingleRecord<UsersInfo>(userInfo.UId);
            usersInfo.UName = userInfo.Name;
            usersInfo.UFname = userInfo.Fname;
            usersInfo.ULName = userInfo.LName;
            usersInfo.UGender = userInfo.Gender;
            usersInfo.UDOB = userInfo.DOB;
            _dbCommands.ActionState(usersInfo, System.Data.Entity.EntityState.Modified);
            return _dbCommands.Save();
        }

        public bool Update(Models.CompDetail compDetail)
        {
            _dbCommands.ActionState(Assgin(compDetail), System.Data.Entity.EntityState.Modified);
            return _dbCommands.Save();
        }

        public bool DeleteWork(Guid id)
        {
            _dbCommands.ActionState(_dbCommands.FetchSingleRecord<DB.UserCompDetail>(id), System.Data.Entity.EntityState.Deleted);
            return _dbCommands.Save();
        }

        public bool DeleteLocation(Guid id)
        {
            _dbCommands.ActionState(_dbCommands.FetchSingleRecord<DB.LocationDetail>(id), System.Data.Entity.EntityState.Deleted);
            return _dbCommands.Save();
        }

        public bool Update(Models.UserCompDetail compDetail)
        {
            _dbCommands.ActionState(Assgin(compDetail), System.Data.Entity.EntityState.Modified);
            return _dbCommands.Save();
        }

        public bool Update(Models.LocationDetail location)
        {
            _dbCommands.ActionState(Assgin(location), System.Data.Entity.EntityState.Modified);
            return _dbCommands.Save();
        }

        public ActionReturn Insert(Models.UserCompDetail userComp)
        {
            DB.UserCompDetail userCompDetail = Assgin(userComp);
            _dbCommands.Insert(userCompDetail);
            bool status = _dbCommands.Save();
            return new ActionReturn()
            {
                Id = userCompDetail.UCId,
                Status = status
            };
        }

        private DB.UserCompDetail Assgin(Models.UserCompDetail userComp)
        {
            return new DB.UserCompDetail()
            {
                UCId = userComp.Id,
                UCCOMPID = userComp.CompId,
                UCStartDate = userComp.StartDate,
                UCEndDate = userComp.EndDate,
                UUID = userComp.UUID,
                IsActive = userComp.IsActive
            };
        }

        public ActionReturn Insert(Models.CompDetail comp)
        {
            DB.CompDetail compDetail = Assgin(comp);
            _dbCommands.Insert(compDetail);
            bool status = _dbCommands.Save();
            return new ActionReturn()
            {
                Id = compDetail.CId,
                Status = status
            };
        }

        private DB.CompDetail Assgin(Models.CompDetail comp)
        {
            return new DB.CompDetail()
            {
                CId = comp.Id,
                CAID = comp.LocationID,
                CName = comp.Name,
                CStatus = comp.Status,
                IsActive = comp.IsActive
            };
        }

        public ActionReturn Insert(Models.LocationDetail location)
        {
            DB.LocationDetail detail = Assgin(location);
            _dbCommands.Insert(detail);
            bool status = _dbCommands.Save();
            return new ActionReturn()
            {
                Id = detail.AID,
                Status = status
            };
        }

        private DB.LocationDetail Assgin(Models.LocationDetail location)
        {
            return new DB.LocationDetail()
            {
                AID = location.ID,
                ACode = location.Code,
                ACity = location.City,
                ACountry = location.Country,
                Address = location.Address,
                ALocation = location.Location,
                AStrees = location.Strees,
                AState = location.State,
                ALat = location.Lat,
                ALng = location.Lng,
                IsActive = location.IsActive,
                Refernceid = location.Refernceid
            };
        }

        public IEnumerable<Models.LocationDetail> GetLocation(SearchParams search)
        {
            return GetLocationDetail(_dbCommands.FetchRecords<DB.LocationDetail>(new CommonLibrary.Filter() { FilterOn = search.FilterOn }).ToList());
        }

        public IEnumerable<UserInfo> FilterByNameValue(string propName, object propValue)
        {
            List<UserInfo> userInfo = new List<UserInfo>();
            _dbCommands.FetchRecords<UsersInfo>(propName, propValue).ToList().ForEach(x =>
            {
                userInfo.Add(GetUserInfo(x));
            });
            return userInfo;
        }

        private UserInfo GetUserInfo(UsersInfo usersInfo)
        {
            return new UserInfo()
            {
                Name = usersInfo.UName,
                Fname = usersInfo.UFname,
                LName = usersInfo.ULName,
                DOB = usersInfo.UDOB,
                Emailid = usersInfo.UEmailid,
                Gender = usersInfo.UGender,
                About = usersInfo.UAbout,
                Desc = usersInfo.UDesc,
                Primarynumber = usersInfo.UPrimarynumber,
                Secondarynumber = usersInfo.USecondarynumber,
                Secondarycode = usersInfo.USecondarycode,
                Primarynumbercode = usersInfo.UPrimarynumbercode,
                Wallimage = usersInfo.UWallimage,
                UId = usersInfo.UId,
                Profileimage = usersInfo.UProfileimage,
                LocationDetail = GetLocationDetail(usersInfo.LocationDetail),
                UserCompDetail = GetUserCompDetail(usersInfo.UserCompDetail),
                IsActive = usersInfo.IsActive,
                Status = usersInfo.UStatus
            };
        }


        private List<Models.CompDetail> GetCompDetail(DB.CompDetail source)
        {
            List<Models.CompDetail> _compDetail = new List<Models.CompDetail>();
            _compDetail.Add(new Models.CompDetail()
            {
                Id = source.CId,
                Name = source.CName,
                Location = GetLocationDetail(_dbCommands.FetchRecords<DB.LocationDetail>("refernceid", source.CId).ToList()),
                Status = source.CStatus,
                IsActive = source.IsActive

            });
            return _compDetail;
        }

        private IEnumerable<Models.CompDetail> GetCompDetail(ICollection<DB.CompDetail> source)
        {
            List<Models.CompDetail> _compDetail = new List<Models.CompDetail>();
            if (source != null)
            {
                while (source.GetEnumerator().MoveNext())
                {
                    _compDetail.Add(new Models.CompDetail()
                    {
                        Id = source.GetEnumerator().Current.CId,
                        Name = source.GetEnumerator().Current.CName,
                        Status = source.GetEnumerator().Current.CStatus,
                        LocationID = source.GetEnumerator().Current.CAID,
                        Location = GetLocationDetail(source.GetEnumerator().Current.LocationDetail),
                        IsActive = source.GetEnumerator().Current.IsActive,
                    });
                }
            }
            return _compDetail;
        }

        private IEnumerable<Models.LocationDetail> GetLocationDetail(ICollection<DB.LocationDetail> source)
        {
            List<Models.LocationDetail> locationDetails = new List<Models.LocationDetail>();
            if (source != null)
            {
                foreach (var item in source.ToList())
                {
                    locationDetails.Add(new Models.LocationDetail()
                    {
                        ID = item.AID,
                        Code = item.ACode,
                        City = item.ACity,
                        State = item.AState,
                        Country = item.ACountry,
                        Address = item.Address,
                        Location = item.ALocation,
                        Strees = item.AStrees,
                        Lat = item.ALat,
                        Lng = item.ALng,
                        IsActive = item.IsActive,
                        Refernceid = item.Refernceid,
                        GooglePlaceId = item.GooglePlaceId
                    });
                }
            }
            return locationDetails;
        }

        private Models.UserCompDetail GetUserCompDetail(DB.UserCompDetail source)
        {
            Models.UserCompDetail userCompDetail = new Models.UserCompDetail()
            {
                CompDetail = GetCompDetail(_dbCommands.FetchSingleRecord<DB.CompDetail>(source.UCCOMPID)),
                Id = source.UCId,
                StartDate = source.UCStartDate,
                EndDate = source.UCEndDate,
                UUID = source.UUID,
                IsActive = source.IsActive
            };

            return userCompDetail;
        }

        private IEnumerable<Models.UserCompDetail> GetUserCompDetail(ICollection<DB.UserCompDetail> source)
        {
            List<Models.UserCompDetail> userCompDetail = new List<Models.UserCompDetail>();
            if (source != null)
            {
                while (source.GetEnumerator().MoveNext())
                {
                    userCompDetail.Add(new Models.UserCompDetail()
                    {
                        Id = source.GetEnumerator().Current.UCId,
                        CompId = source.GetEnumerator().Current.UCCOMPID,
                        StartDate = source.GetEnumerator().Current.UCStartDate,
                        EndDate = source.GetEnumerator().Current.UCEndDate,
                        IsActive = source.GetEnumerator().Current.IsActive
                    });
                }
            }
            return userCompDetail;
        }
    }
}