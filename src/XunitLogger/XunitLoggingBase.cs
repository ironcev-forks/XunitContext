﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xunit.Abstractions;
using XunitLogger;

public abstract class XunitLoggingBase :
    IDisposable
{
    public ITestOutputHelper Output { get; }
    public Context Context { get; }

    public XunitLoggingBase(
        ITestOutputHelper output,
        [CallerFilePath] string sourceFilePath = "")
    {
        Guard.AgainstNull(output, nameof(output));
        Guard.AgainstNullOrEmpty(sourceFilePath, nameof(sourceFilePath));
        Output = output;
        Context = XunitLogging.Register(output, sourceFilePath);
    }

    public void WriteLine(string value)
    {
        Context.WriteLine(value);
    }

    public void WriteLine()
    {
        Context.WriteLine();
    }

    public void Write(string value)
    {
        Context.Write(value);
    }

    public IReadOnlyList<string> Logs => Context.LogMessages;

    public virtual void Dispose()
    {
        Context.Flush();
    }
}