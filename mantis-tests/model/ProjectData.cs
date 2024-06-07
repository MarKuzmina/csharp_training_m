using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace mantis_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        [Column(Name = "id")]
        public string Id { get; set; }

        [Column(Name = "name")]
        public string Name { get; set; }

        [Column(Name = "description")]

        public string Description { get; set; }
        public ProjectData()
        {
        }
        /*public ProjectData(string name) 
        {
            Name = name;
        }*/

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Name == other.Name) && (Description == other.Description);
        }

        public override int GetHashCode()
        {

            return Name.GetHashCode() ^ Description.GetHashCode();
        }

        public override string ToString()
        {
            return "name = " + Name
                + "\ndescription = " + Description;
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Name == other.Name)
            {
                return Name.CompareTo(other.Name);
            }

            return Name.CompareTo(other.Name);
        }

        public static List<ProjectData> GetProjectsListDB()
        {
            using (MantisDB db = new MantisDB())
            {
                return (from p in db.Projects select p).ToList();            
            }
        }
    }
}
