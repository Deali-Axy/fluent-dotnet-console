using FluentResults;

namespace FluentConsole.Template.Services;

public interface IService {
    Task<Result> Run();
}