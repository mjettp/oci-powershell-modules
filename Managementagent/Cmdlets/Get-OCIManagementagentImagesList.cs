/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200202
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.ManagementagentService.Requests;
using Oci.ManagementagentService.Responses;
using Oci.ManagementagentService.Models;

namespace Oci.ManagementagentService.Cmdlets
{
    [Cmdlet("Get", "OCIManagementagentImagesList")]
    [OutputType(new System.Type[] { typeof(Oci.ManagementagentService.Models.ManagementAgentImageSummary), typeof(Oci.ManagementagentService.Responses.ListManagementAgentImagesResponse) })]
    public class GetOCIManagementagentImagesList : OCIManagementAgentCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The ID of the compartment from which the Management Agents to be listed.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.ManagementagentService.Requests.ListManagementAgentImagesRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for platformType is descending. Default order for version is descending. If no value is specified platformType is default.")]
        public System.Nullable<Oci.ManagementagentService.Requests.ListManagementAgentImagesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the entire platform name given.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Filter to return only Management Agents in the particular lifecycle state.")]
        public System.Nullable<Oci.ManagementagentService.Models.LifecycleStates> LifecycleState { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListManagementAgentImagesRequest request;

            try
            {
                request = new ListManagementAgentImagesRequest
                {
                    CompartmentId = CompartmentId,
                    OpcRetryToken = OpcRetryToken,
                    OpcRequestId = OpcRequestId,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    Name = Name,
                    LifecycleState = LifecycleState
                };
                IEnumerable<ListManagementAgentImagesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.Items, true);
                }
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

        private RequestDelegate GetRequestDelegate()
        {
            IEnumerable<ListManagementAgentImagesResponse> DefaultRequest(ListManagementAgentImagesRequest request) => Enumerable.Repeat(client.ListManagementAgentImages(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListManagementAgentImagesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListManagementAgentImagesResponse response;
        private delegate IEnumerable<ListManagementAgentImagesResponse> RequestDelegate(ListManagementAgentImagesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
