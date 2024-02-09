namespace HRMSv4.Client.Service
{
    public class InfoGlobalClass
    {
        string[] Level;
        public string[] LevelArray
        {
            get { return new string[8] { "None", "Read and Write Only", "Elementary", "High School", "Junior High School", "Senior High School", "College", "Graduate Studies" }; }
        }

        string[] Degree;
        public string[] DegreeArray
        {
            get { return new string[2] {"Bachelor", "Vocational" }; }
        }

        string[] Graduate;
        public string[] GraduateArray
        {
            get { return new string[2] { "Masteral", "Doctorate" }; }
        }

        string[] Gender;
        public string[] GenderArray
        {
            get { return new string[3] { "", "Male", "Female" }; }
        }

        string[] CivilStatus;
        public string[] CivilStatusArray
        {
            get { return new string[5] { "", "Single", "Married", "Divorced", "Widowed" }; }
        }

        string[] Relationship;
        public string[] RelationshipArray
        {
            get { return new string[6] { "", "Father", "Mother", "Child", "Sibling", "Other" }; }
        }

        string[] Course;
        public string[] CourseArray
        {
            get { return new string[5] { "", "", "", "", "" }; }
        }

        string[] CompetencyType;
        public string[] CompetencyTypeArray
        {
            get { return new string[3] { "Core Competency", "Functional Competency", "Leadership Competency" }; }
        }

        string[] CompetencyLevel;
        public string[] CompetencyLevelArray
        {
            get { return new string[4] { "Basic", "Intermediate", "Advanced", "Superior" }; }
        }
    }
}
