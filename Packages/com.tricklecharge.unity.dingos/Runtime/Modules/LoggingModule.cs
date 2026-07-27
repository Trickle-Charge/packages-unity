using System;
using System.Collections.Generic;
using System.CommandLine;

using TrickleCharge.DingOS.Core;

using UnityEngine;

namespace TrickleCharge.DingOS.Unity.Modules
{
public class LoggingModule : ICommandModule<Command>
{
    /// <inheritdoc />
    public IEnumerable<Command> GetCommands(IShellEnvironment environment)
    {
        yield return DebugLog();
    }

    private enum LogLevel
    {
        Info,
        Warning,
        Error
    }

    public static Command DebugLog()
    {
        Option<string> levelOption = new("--level", "-l")
        {
            Description = "The logging level",
            Arity = ArgumentArity.ZeroOrOne
        };

        Argument<string> textArgument = new("text")
        {
            Description = "The text to log",
            Arity = ArgumentArity.OneOrMore
        };

        Command logCommand = new("debug-log")
        {
            levelOption,
            textArgument
        };
        logCommand.Description = "Log a debug message";
        logCommand.Aliases.Add("log");

        logCommand.SetAction(parseResult =>
        {
            string logLevel = parseResult.GetValue(levelOption);
            string logText = parseResult.GetValue(textArgument);

            LogLevel level = Enum.Parse<LogLevel>(logLevel, ignoreCase: true);
            switch (level)
            {
                case LogLevel.Info:
                    Debug.Log(logText);
                    break;
                case LogLevel.Warning:
                    Debug.LogWarning(logText);
                    break;
                case LogLevel.Error:
                    Debug.LogError(logText);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
            }
        });

        return logCommand;
    }
}
}
