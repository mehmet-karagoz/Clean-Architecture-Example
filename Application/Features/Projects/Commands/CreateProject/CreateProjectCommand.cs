using Application.Interfaces.Repositories;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Projects.Commands.CreateProject
{
    public partial class CreateProjectCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Response<int>>
    {
        private readonly IProjectRepositoryAsync _projectRepository;
        private readonly IMapper _mapper;
        public CreateProjectCommandHandler(IProjectRepositoryAsync projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _mapper.Map<Project>(request);
            await _projectRepository.AddAsync(project);
            return new Response<int>(project.Id);
        }
    }
}
