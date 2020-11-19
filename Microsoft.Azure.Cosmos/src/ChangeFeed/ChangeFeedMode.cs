﻿// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

namespace Microsoft.Azure.Cosmos
{
    using System;
    using Microsoft.Azure.Cosmos.ChangeFeed;

    /// <summary>
    /// Base class for the change feed mode <see cref="ChangeFeedRequestOptions"/>.
    /// </summary>
    /// <remarks>Use one of the static constructors to generate a ChangeFeedMode option.</remarks>
#if PREVIEW
    public
#else
    internal
#endif
        abstract class ChangeFeedMode
    {
        /// <summary>
        /// Initializes an instance of the <see cref="ChangeFeedMode"/> class.
        /// </summary>
        internal ChangeFeedMode()
        {
            // Internal so people can't derive from this type.
        }

        internal abstract void Accept(RequestMessage requestMessage);

        /// <summary>
        /// Creates a <see cref="ChangeFeedMode"/>  to receive incremental item changes.
        /// </summary>
        /// <returns>A <see cref="ChangeFeedMode"/>  to receive incremental item changes.</returns>
        public static ChangeFeedMode Incremental()
        {
            return ChangeFeedModeIncremental.Instance;
        }

        /// <summary>
        /// Creates a <see cref="ChangeFeedMode"/>  to receive notifications for insertions, updates, and delete operations.
        /// </summary>
        /// <remarks>
        /// A container with a change feed policy configured is required. The delete operations will be included only within the configured retention period.
        /// </remarks>
        /// <returns>A <see cref="ChangeFeedMode"/>  to receive notifications for insertions, updates, and delete operations.</returns>
        public static ChangeFeedMode FullFidelity()
        {
            return ChangeFeedModeIFullFidelity.Instance;
        }
    }
}