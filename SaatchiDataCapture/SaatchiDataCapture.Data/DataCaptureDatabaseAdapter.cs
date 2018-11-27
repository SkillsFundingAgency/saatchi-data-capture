﻿namespace SaatchiDataCapture.Data
{
    using System;
    using Meridian.InterSproc;
    using SaatchiDataCapture.Data.Definitions;
    using SaatchiDataCapture.Data.Models;

    /// <summary>
    /// Implements <see cref="IDataCaptureDatabaseAdapter" />.
    /// </summary>
    public class DataCaptureDatabaseAdapter : IDataCaptureDatabaseAdapter
    {
        private readonly IDataCaptureDatabaseContract dataCaptureDatabaseContract;

        /// <summary>
        /// Initialises a new instance of the
        /// <see cref="DataCaptureDatabaseAdapter" /> class.
        /// </summary>
        /// <param name="dataCaptureDatabaseAdapterSettingsProvider">
        /// An instance of type
        /// <see cref="IDataCaptureDatabaseAdapterSettingsProvider" />.
        /// </param>
        public DataCaptureDatabaseAdapter(
            IDataCaptureDatabaseAdapterSettingsProvider dataCaptureDatabaseAdapterSettingsProvider)
        {
            string dataCaptureDatabaseConnectionString =
                dataCaptureDatabaseAdapterSettingsProvider.DataCaptureDatabaseConnectionString;

            this.dataCaptureDatabaseContract =
                SprocStubFactory.Create<IDataCaptureDatabaseContract>(
                    dataCaptureDatabaseConnectionString);
        }

        /// <inheritdoc />
        public CreatedEntityReference CreatePerson(
            DateTime created,
            DateTime enrolled,
            string firstName,
            string lastName)
        {
            CreatedEntityReference toReturn =
                this.dataCaptureDatabaseContract.CreatePerson(
                    created,
                    enrolled,
                    firstName,
                    lastName);

            return toReturn;
        }
    }
}