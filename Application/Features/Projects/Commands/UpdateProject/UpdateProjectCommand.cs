using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Response<int>>
        {
            private readonly IProjectRepositoryAsync _projectRepository;
            public UpdateProjectCommandHandler(IProjectRepositoryAsync projectRepository)
            {
                _projectRepository = projectRepository;
            }
            public async Task<Response<int>> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
            {
                var project = await _projectRepository.GetByIdAsync(command.Id);

                if (project == null)
                {
                    throw new ApiException($"Project Not Found.");
                }
                else
                {
                    project.Name = command.Name;
                    project.Description = command.Description;
                    await _projectRepository.UpdateAsync(project);
                    return new Response<int>(project.Id);
                }
            }
        }
    }
}
