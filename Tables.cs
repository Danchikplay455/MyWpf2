using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using System.Security.RightsManagement;

    public class client
    {
        [Key]
        public int id { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? type_user { get; set; }  
        public static client? currentUser { get; set; }
    }
    public class route
    {
        [Key]
        public int id { get; set; }
        public string? bus { get; set; }
        public string? driver { get; set; }
        public string? city { get; set; }
        public static route? currentRoute { get; set; }
        
    }
    public class ticket
    {
        [Key]
        public int id { get; set; }
        public int? route { get; set; }
        public int? client { get; set; }
        public int? price { get; set; }
        public static ticket? currentTicket { get; set; }
    }
