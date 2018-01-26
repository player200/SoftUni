namespace ModPanel.App.Services.Contracts
{
    using ModPanel.App.Data.Models;
    using ModPanel.App.Models.Logs;
    using System.Collections.Generic;

    public interface ILogService
    {
        void Create(string admin, LogType type, string additionalInformation);

        IEnumerable<LogModel> All();
    }
}