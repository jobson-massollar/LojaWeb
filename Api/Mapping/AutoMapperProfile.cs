using Api.Contracts;
using Application.Interfaces.Entry;
using AutoMapper;
using Domain.Model;

namespace Api.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Mapeamento dos Requests
        CreateMap<CriarClienteRequest, CriarClienteData>();

        CreateMap<CriarProdutoRequest, CriarProdutoData>();

        CreateMap<CriarPedidoRequest, CriarPedidoData>();

        CreateMap<ItemPedidoRequest, ItemPedidoData>();

        // Mapeamento dos Responses
        CreateMap<Cliente, ClienteResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.CPF.Valor))
            .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Endereco.Logradouro))
            .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Endereco.Numero))
            .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => src.Endereco.Complemento))
            .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Endereco.Bairro))
            .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Endereco.Cep.Valor))
            .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Endereco.UF.Sigla))
            .ForMember(dest => dest.DDD, opt => opt.MapFrom(src => src.Telefone.DDD))
            .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone.Numero));

        CreateMap<UF, UFResponse>();

        CreateMap<Produto, ProdutoResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CodigoBarras, opt => opt.MapFrom(src => src.CodigoBarras.Valor))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(dest => dest.Moeda, opt => opt.MapFrom(src => src.Preco.Moeda))
            .ForMember(dest => dest.Preco, opt => opt.MapFrom(src => src.Preco.Valor));

        CreateMap<Preferencia, PreferenciaResponse>();

        CreateMap<Pedido, PedidoResponse>();

        CreateMap<Item, ItemPedidoResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Quantidade, opt => opt.MapFrom(src => src.Quantidade))
            .ForMember(dest => dest.Moeda, opt => opt.MapFrom(src => src.Preco.Moeda))
            .ForMember(dest => dest.Preco, opt => opt.MapFrom(src => src.Preco.Valor))
            .ForMember(dest => dest.Produto, opt => opt.MapFrom(src => src.Produto.Descricao));

    }
}
