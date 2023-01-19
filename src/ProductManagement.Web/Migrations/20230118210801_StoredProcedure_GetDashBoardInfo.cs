using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManagement.Web.Migrations
{
    public partial class StoredProcedure_GetDashBoardInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"

CREATE   PROCEDURE `sp_GetDashBoardInfo` (
						p_PageIndex int,
						p_PageSize int,
						p_SearchText nvarchar(250),
						p_OrderBy nvarchar(50),
						out p_Total int,
						out p_TotalDisplay int)

						BEGIN
							Declare v_sql nvarchar(4000);
							Declare v_totalSql nvarchar(4000);
							Declare v_countSql nvarchar(4000);
							Declare v_paramList longtext;
							Declare v_totalparamList longtext;
							Declare v_countparamList longtext;

	
							SET v_totalSql = 'SELECT @Total = COUNT(*) FROM workers w left join workersinformation wi on w.Roll=wi.Roll WHERE 1 = 1';
							SET v_countSql = 'SELECT @TotalDisplay = COUNT(*) FROM workers w left join workersinformation wi on w.Roll=wi.Roll WHERE 1 = 1';

						END;
							
							IF p_SearchText IS NOT NULL THEN
								SET v_countSql = CONCAT(v_countSql , ' AND w.Roll LIKE ''%'' + @xSearchText + ''%''');
							END IF;

							SET v_sql = 'select w.Roll,w.User,w.Name,w.DateOfBirth,w.PermanentDistrict,w.Quota,wi.BarCodeData,wi.Price from workers w left join workersinformation wi on w.Roll=wi.Roll';

							IF p_SearchText IS NOT NULL THEN
								SET v_sql = Concat(v_sql , ' AND P.Title LIKE ''%'' + @xSearchText + ''%''');
							END IF;

							SET v_sql = Concat(v_sql , ' ORDER BY ', p_OrderBy ,' OFFSET @PageSize * (@PageIndex - 1) 
								ROWS FETCH NEXT @PageSize ROWS ONLY');

							SET v_totalparamList = ' @Total int output';

							execute sp_executesql v_totalSql, v_totalparamList,
								p_Total = p_Total output;

							SET v_countparamList = '@TotalDisplay int output';

							execute sp_executesql v_countSql, v_countparamList,
								p_TotalDisplay = p_TotalDisplay output;

							SET v_paramList = ' 
								@xSearchText nvarchar(250),
								@PageIndex int, 
								@PageSize int';

							execute sp_executesql v_sql, v_paramList,
								p_SearchText,
								p_PageIndex,
								p_PageSize;



						GO";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DROP PROCEDURE [dbo].[sp_GetDashBoardInfo]";
            migrationBuilder.Sql(sql);
        }
    }
}
