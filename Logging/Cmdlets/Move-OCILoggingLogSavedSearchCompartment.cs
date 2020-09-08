/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200531
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.LoggingService.Requests;
using Oci.LoggingService.Responses;
using Oci.LoggingService.Models;

namespace Oci.LoggingService.Cmdlets
{
    [Cmdlet("Move", "OCILoggingLogSavedSearchCompartment")]
    [OutputType(new System.Type[] { typeof(void), typeof(Oci.LoggingService.Responses.ChangeLogSavedSearchCompartmentResponse) })]
    public class MoveOCILoggingLogSavedSearchCompartment : OCILoggingManagementCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"OCID of the logSavedSearch")]
        public string LogSavedSearchId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Contains details indicating which compartment the resource should move to")]
        public ChangeLogSavedSearchCompartmentDetails ChangeLogSavedSearchCompartmentDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (e.g., if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ChangeLogSavedSearchCompartmentRequest request;

            try
            {
                request = new ChangeLogSavedSearchCompartmentRequest
                {
                    LogSavedSearchId = LogSavedSearchId,
                    ChangeLogSavedSearchCompartmentDetails = ChangeLogSavedSearchCompartmentDetails,
                    OpcRetryToken = OpcRetryToken,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.ChangeLogSavedSearchCompartment(request).GetAwaiter().GetResult();
                WriteOutput(response);
                FinishProcessing(response);
            }
            catch (Exception ex)
            {
                TerminatingErrorDuringExecution(ex);
            }
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
            TerminatingErrorDuringExecution(new OperationCanceledException("Cmdlet execution interrupted"));
        }

        private ChangeLogSavedSearchCompartmentResponse response;
    }
}