﻿namespace DWC_A
{
    public interface IArchiveFolder
    {
        bool ShouldCleanup { get; }
        void DeleteFolder();
        string Extract();
    }
}