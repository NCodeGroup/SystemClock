#region Copyright Preamble

//
//    Copyright @ 2023 NCode Group
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

#endregion

using System;
using System.Diagnostics;
using System.Threading;
using Xunit;

namespace NCode.SystemClock.Tests;

/// <summary/>
public class SystemClockMillisecondsAccuracyTests
{
    /// <summary/>
    [Fact]
    public void GetUtcNowHasNonZeroMilliseconds()
    {
        var sw = Stopwatch.StartNew();

        var startTime = SystemClockMillisecondsAccuracy.GetUtcNow();

        SpinWait.SpinUntil(() => sw.ElapsedMilliseconds > 1, 2);

        var endTime = SystemClockMillisecondsAccuracy.GetUtcNow();

        Assert.True(sw.ElapsedMilliseconds > 0);

        var duration = endTime - startTime;
        Assert.NotEqual(0.0, duration.TotalMilliseconds);
    }

    /// <summary/>
    [Fact]
    public void GetUtcNowAccuracyIsMilliseconds()
    {
        SystemClockMillisecondsAccuracy.GetUtcNow();

        var nowActual = SystemClockMillisecondsAccuracy.GetUtcNow();
        var nowExpected = DateTimeOffset.UtcNow;

        var diff = nowExpected - nowActual;
        var ms = Math.Abs(diff.TotalMilliseconds);
        Assert.InRange(ms, 0, 100.0);
    }
}