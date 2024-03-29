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

namespace NCode.SystemClock;

/// <summary>
/// Provides access to the normal system clock with accuracy in seconds.
/// </summary>
/// <remarks>
/// This implementation is particularly useful in JWT authentication because
/// <code>expires_in</code> only supports whole seconds and milliseconds do
/// not round-trip when serializing.
/// </remarks>
public interface ISystemClockSecondsAccuracy : ISystemClock
{
    // nothing
}