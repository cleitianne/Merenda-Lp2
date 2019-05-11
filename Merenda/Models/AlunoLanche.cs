namespace Merenda.Models
{
    public class AlunoLanche
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int LancheId { get; set; }
        public Aluno Aluno { get; set; }
        public Lanche Lanche { get; set; }

        
    }
}