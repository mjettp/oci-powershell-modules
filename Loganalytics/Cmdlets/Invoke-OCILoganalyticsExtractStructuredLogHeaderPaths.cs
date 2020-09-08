/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200601
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.LoganalyticsService.Requests;
using Oci.LoganalyticsService.Responses;
using Oci.LoganalyticsService.Models;

namespace Oci.LoganalyticsService.Cmdlets
{
    [Cmdlet("Invoke", "OCILoganalyticsExtractStructuredLogHeaderPaths")]
    [OutputType(new System.Type[] { typeof(Oci.LoganalyticsService.Models.ExtractLogHeaderResults), typeof(Oci.LoganalyticsService.Responses.ExtractStructuredLogHeaderPathsResponse) })]
    public class InvokeOCILoganalyticsExtractStructuredLogHeaderPaths : OCILogAnalyticsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Log Analytics namespace used for the request.")]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"parser definition")]
        public LogAnalyticsParser LoganParserDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"type - possible values are xml or json")]
        public System.Nullable<Oci.LoganalyticsService.Requests.ExtractStructuredLogHeaderPathsRequest.ParserTypeEnum> ParserType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ExtractStructuredLogHeaderPathsRequest request;

            try
            {
                request = new ExtractStructuredLogHeaderPathsRequest
                {
                    NamespaceName = NamespaceName,
                    LoganParserDetails = LoganParserDetails,
                    ParserType = ParserType,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId
                };

                response = client.ExtractStructuredLogHeaderPaths(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ExtractLogHeaderResults);
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

        private ExtractStructuredLogHeaderPathsResponse response;
    }
}
