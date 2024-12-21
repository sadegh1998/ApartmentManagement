namespace _0_Framework.Infrstructure
{
    public class PermissonDto
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public PermissonDto(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
