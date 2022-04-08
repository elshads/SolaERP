namespace SolaERP.Server.ModelService
{
    public class AnalysisService
    {
        public async Task<IEnumerable<Analysis>> GetAll(int analysisTypeId)
        {
            IEnumerable<Analysis> result = new List<Analysis>();
            try
            {
                var view = (analysisTypeId == 1 ? "ExpenseTypesList" : analysisTypeId == 2 ? "GroupProjectsList" : analysisTypeId == 3 ? "ProjectCodesList" : "AnalysisServiceError");
                using (var cn = new SqlConnection(SqlConfiguration.StaticConnectionString))
                {
                    var _result = await cn.QueryAsync<Analysis>($"SELECT * FROM dbo.{view}");
                    if (_result.Any()) result = _result;
                }
            }
            catch (Exception e)
            {
                var message = e.Message;
            }
            return result;
        }
    }
}
