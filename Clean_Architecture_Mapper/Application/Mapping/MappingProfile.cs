using Application.Feature.Product.Commands;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    internal class MappingProfile :Profile
    {
        public MappingProfile()
        {
            // CreateMap<CreateProductCommand, Domainn.Entities.Product>();//<Source,Destination> <- to opp .ReverseMap()

            // when Property name change (Entity) Description to Remarks (in CreateProductCommand)

            CreateMap<CreateProductCommand, Domainn.Entities.Product>()
                .ForMember(destination => destination.Description, source => source.MapFrom(x => x.Remarks));


        }
    }
}
