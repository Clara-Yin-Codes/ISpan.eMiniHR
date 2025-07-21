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

                var item = MapperHelper.Mapper.Map<UsersDto>(emp);

                item.UserId = newId;

                db.Users.Add(item);

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
                    throw new Exception("編號不可為空");
                }

                var item = db.Users.Find(keyId);
                if (item == null)
                {
                    throw new Exception("找不到資料!");
                }

                MapperHelper.Mapper.Map(source, item);

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
