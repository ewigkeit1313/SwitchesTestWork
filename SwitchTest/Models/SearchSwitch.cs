using SwitchTest.DAL;

namespace SwitchTest.Models
{
    public class SearchSwitch
    {

        private readonly SwitchesDBContext _switchesDBContext;

        public SearchSwitch(SwitchesDBContext switchesDBContext)
        {
            _switchesDBContext = switchesDBContext;
        }

        public IQueryable<Switch> GetSwithes(SwitchSearchModel searchModel)
        {
            var result = _switchesDBContext.Switches.AsQueryable();

            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.SwitchModel))
                    result = result.Where(x => x.Model.Contains(searchModel.SwitchModel));
                if (!string.IsNullOrEmpty(searchModel.Ip))
                    result = result.Where(x => x.Ip.Contains(searchModel.Ip));
                if (!string.IsNullOrEmpty(searchModel.Mac))
                    result = result.Where(x => x.Mac.Contains(searchModel.Mac));
                if (!string.IsNullOrEmpty(searchModel.VLan))
                    result = result.Where(x => x.VLan.Contains(searchModel.VLan));
                if (!string.IsNullOrEmpty(searchModel.Floor))
                    result = result.Where(x => x.Floor.Contains(searchModel.Floor));
                if (!string.IsNullOrEmpty(searchModel.Comment))
                    result = result.Where(x => x.Comment.Contains(searchModel.Comment));
            }
            return result;
        }

    }
}
