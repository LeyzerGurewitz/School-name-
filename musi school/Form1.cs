using static musi_school.Service.MUsicSchoolService;
namespace musi_school

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateXMLIfNotExists();
            InsrtClassroom("guitar");
            AddTeacher("guitar", "yoosi levi");
            AddStudent("guitar","leyzer", "guitar");
        }
    }
}
