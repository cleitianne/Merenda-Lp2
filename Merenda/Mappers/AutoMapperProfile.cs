using AutoMapper;
using Merenda.Models;
using Merenda.ViewModels;

namespace Merenda.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AlunoLanche, RelatorioViewModel>()
                .ForMember(vm => vm.Curso, e => e.ResolveUsing(en => en.Aluno.Curso))
                .ForMember(vm => vm.Nivel, e => e.ResolveUsing(en => en.Aluno.Nivel))
                .ForMember(vm => vm.Nome,  e => e.ResolveUsing(en => en.Aluno.Nome))
                .ForMember(vm => vm.COD_Estoque, e => e.ResolveUsing(en => en.Lanche.COD_Estoque))
                .ReverseMap();

        }

    }
}