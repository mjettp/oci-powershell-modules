/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200501
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.OcvpService.Requests;
using Oci.OcvpService.Responses;
using Oci.OcvpService.Models;

namespace Oci.OcvpService.Cmdlets
{
    [Cmdlet("Get", "OCIOcvpSddcsList")]
    [OutputType(new System.Type[] { typeof(Oci.OcvpService.Models.SddcCollection), typeof(Oci.OcvpService.Responses.ListSddcsResponse) })]
    public class GetOCIOcvpSddcsList : OCISddcCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the compartment.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the availability domain that the Compute instances are running in.

Example: `Uocm:PHX-AD-1`")]
        public string ComputeAvailabilityDomain { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the given display name exactly.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The maximum number of results per page, or items to return in a paginated ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For list pagination. The value of the `opc-next-page` response header from the previous ""List"" call. For important details about how pagination works, see [List Pagination](https://docs.cloud.oracle.com/iaas/Content/API/Concepts/usingapi.htm#nine).")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either ascending (`ASC`) or descending (`DESC`). The DISPLAYNAME sort order is case sensitive.")]
        public System.Nullable<Oci.OcvpService.Models.SortOrders> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. You can provide one sort order (`sortOrder`). Default order for TIMECREATED is descending. Default order for DISPLAYNAME is ascending. The DISPLAYNAME sort order is case sensitive.

**Note:** In general, some ""List"" operations (for example, `ListInstances`) let you optionally filter by availability domain if the scope of the resource type is within a single availability domain. If you call one of these ""List"" operations without specifying an availability domain, the resources are grouped by availability domain, then sorted.")]
        public System.Nullable<Oci.OcvpService.Requests.ListSddcsRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The lifecycle state of the resource.")]
        public System.Nullable<Oci.OcvpService.Models.LifecycleStates> LifecycleState { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListSddcsRequest request;

            try
            {
                request = new ListSddcsRequest
                {
                    CompartmentId = CompartmentId,
                    ComputeAvailabilityDomain = ComputeAvailabilityDomain,
                    DisplayName = DisplayName,
                    Limit = Limit,
                    Page = Page,
                    SortOrder = SortOrder,
                    SortBy = SortBy,
                    OpcRequestId = OpcRequestId,
                    LifecycleState = LifecycleState
                };
                IEnumerable<ListSddcsResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.SddcCollection, true);
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
            IEnumerable<ListSddcsResponse> DefaultRequest(ListSddcsRequest request) => Enumerable.Repeat(client.ListSddcs(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListSddcsResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListSddcsResponse response;
        private delegate IEnumerable<ListSddcsResponse> RequestDelegate(ListSddcsRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
