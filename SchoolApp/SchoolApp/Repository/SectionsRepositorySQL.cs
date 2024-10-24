using SchoolApp.Models;

namespace SchoolApp.Repository
{
     class SectionsRepositorySQL : BaseRepositorySQL<Section>
    {
        public SectionsRepositorySQL(SchoolContext context) : base(context) { }
      
    }
}
