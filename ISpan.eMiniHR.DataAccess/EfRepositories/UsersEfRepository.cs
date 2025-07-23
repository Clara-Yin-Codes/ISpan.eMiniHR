using ISpan.eMiniHR.DataAccess.Config;
using ISpan.eMiniHR.DataAccess.Helpers;
using ISpan.eMiniHR.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using static ISpan.eMiniHR.DataAccess.Helpers.IdGenerator;

namespace ISpan.eMiniHR.DataAccess.EfRepositories
{
    public class UserEfRepository
    {
        public static int Add(UsersDto emp)
        {
            try
            {
                using var db = new EFDbContext();

                var generatorParam = new IdGeneratorParams
                {
                    tableName = "Users",
                    columnName = "UserId",
                    //prefix = DateTime.Now.ToString("yyMM"), // 例：2507
                    SerialLength = 8 // 流水號最大位數
                };

                string newId = GetNextId(generatorParam); // 取得編號

                var item = MapperHelper.Mapper.Map<UsersEntity>(emp);

                item.UserId = newId;

                db.Users.Add(item);

                if (emp.Permissions != null) {
                    var permissions = emp.Permissions.Where(a => a.Queryable == true || a.Addable == true || a.Editable == true || a.Deletable == true
                         || a.Voidable == true || a.Printable == true || a.Deletable == true || a.Testable == true);

                    var detailList = MapperHelper.Mapper.Map<List<ProgramPermissionsEntity>>(permissions);

                    db.ProgramPermissions.AddRange(detailList); // 多筆新增
                }

                return db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public static int Update(UsersDto source)
        {
            try
            {
                using var db = new EFDbContext();
                var keyId = source.UserId?.Trim();
                if (string.IsNullOrEmpty(keyId))
                {
                    return Add(source);
                }

                var item = db.Users.Find(keyId);
                if (item == null)
                {
                    throw new Exception("找不到資料!");
                }

                MapperHelper.Mapper.Map(source, item);

                // 移除原本的權限資料
                var oldPermissions = db.ProgramPermissions.Where(p => p.EmpId == source.Account);
                db.ProgramPermissions.RemoveRange(oldPermissions);

                // 新增新的權限資料（只保留有勾選的）
                if (source.Permissions != null)
                {
                    var permissions = source.Permissions.Where(p =>
                        p.Queryable == true || p.Addable == true || p.Editable == true || p.Deletable == true ||
                        p.Voidable == true || p.Printable == true || p.Downloadable == true || p.Testable == true
                    );

                    var detailList = MapperHelper.Mapper.Map<List<ProgramPermissionsEntity>>(permissions);

                    db.ProgramPermissions.AddRange(detailList);
                }

                return db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public static int UpdateLastLoginTime(string UserId, DateTime LastTime)
        {
            try
            {
                using var db = new EFDbContext();
                var keyId = UserId?.Trim();
                if (string.IsNullOrEmpty(keyId))
                {
                    throw new Exception("編號不可為空");
                }

                var item = db.Users.Find(keyId);
                if (item == null)
                {
                    throw new Exception("找不到資料!");
                }

                item.LastLoginTime = LastTime; // 更新最後登入時間

                return db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }

        public static int Delete(string keyId)
        {
            try
            {
                using var db = new EFDbContext();
                var item = db.Users.Find(keyId);
                if (item != null)
                {
                    db.Users.Remove(item);

                    // 移除原本的權限資料
                    var oldPermissions = db.ProgramPermissions.Where(p => p.EmpId == item.Account);
                    db.ProgramPermissions.RemoveRange(oldPermissions);

                    return db.SaveChanges();
                }
                return 0;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
