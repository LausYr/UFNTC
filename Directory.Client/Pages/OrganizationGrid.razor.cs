using Directory.Entities.Models;
using Syncfusion.Blazor.Data;

namespace Directory.Client.Pages
{
    public partial class OrganizationGrid
    {
        public static Query GetOrganizationsQuery(Organization value)
        {
            return new Query().Where("OrganizationId", "equal", value.Id);
        }
        public static Query GetSubdivisionQuery(Subdivision value)
        {
            return new Query().Where("SubdivisionId", "equal", value.Id);
        }
    }
}
