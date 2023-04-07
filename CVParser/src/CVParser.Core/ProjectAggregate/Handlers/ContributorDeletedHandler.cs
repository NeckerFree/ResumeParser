﻿using CVParser.Core.ContributorAggregate.Events;
using CVParser.Core.ProjectAggregate.Specifications;
using CVParser.SharedKernel.Interfaces;
using MediatR;

namespace CVParser.Core.ProjectAggregate.Handlers;
public class ContributorDeletedHandler : INotificationHandler<ContributorDeletedEvent>
{
  private readonly IRepository<Project> _repository;

  public ContributorDeletedHandler(IRepository<Project> repository)
  {
    _repository = repository;
  }

  public async Task Handle(ContributorDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    var projectSpec = new ProjectsWithItemsByContributorIdSpec(domainEvent.ContributorId);
    var projects = await _repository.ListAsync(projectSpec, cancellationToken);
    foreach (var project in projects)
    {
      project.Items
        .Where(item => item.ContributorId == domainEvent.ContributorId)
        .ToList()
        .ForEach(item => item.RemoveContributor());
      await _repository.UpdateAsync(project, cancellationToken);
    }
  }
}
