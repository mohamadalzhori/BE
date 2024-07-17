namespace CodeFirst.Common.Exceptions
{
    public class ClassNotFoundException : Exception
    {
        public ClassNotFoundException(int classId) : base($"Class with id {classId} not found")
        {
        }
    }
}
