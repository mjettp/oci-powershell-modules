/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20190325
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Oci.DatacatalogService.Requests;
using Oci.DatacatalogService.Responses;
using Oci.DatacatalogService.Models;

namespace Oci.DatacatalogService.Cmdlets
{
    [Cmdlet("Get", "OCIDatacatalogTypesList")]
    [OutputType(new System.Type[] { typeof(Oci.DatacatalogService.Models.TypeCollection), typeof(Oci.DatacatalogService.Responses.ListTypesResponse) })]
    public class GetOCIDatacatalogTypesList : OCIDataCatalogCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique catalog identifier.")]
        public string CatalogId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Immutable resource name.")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to return only resources that match the specified lifecycle state. The value is case insensitive.")]
        public System.Nullable<Oci.DatacatalogService.Models.LifecycleState> LifecycleState { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Indicates whether the type is internal, making it unavailable for use by metadata elements.")]
        public string IsInternal { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Indicates whether the type can be used for tagging metadata elements.")]
        public string IsTag { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Indicates whether the type is approved for use as a classifying object.")]
        public string IsApproved { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Data type as defined in an external system.")]
        public string ExternalTypeName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Indicates the category of this type . For example, data assets or connections.")]
        public string TypeCategory { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Specifies the fields to return in a type summary response.")]
        public System.Collections.Generic.List<Oci.DatacatalogService.Requests.ListTypesRequest.FieldsEnum> Fields { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The field to sort by. Only one sort order may be provided. Default order for TIMECREATED is descending. Default order for DISPLAYNAME is ascending. If no value is specified TIMECREATED is default.")]
        public System.Nullable<Oci.DatacatalogService.Requests.ListTypesRequest.SortByEnum> SortBy { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The sort order to use, either 'asc' or 'desc'.")]
        public System.Nullable<Oci.DatacatalogService.Requests.ListTypesRequest.SortOrderEnum> SortOrder { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The maximum number of items to return.", ParameterSetName = LimitSet)]
        public System.Nullable<int> Limit { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The page token representing the page at which to start retrieving results. This is usually retrieved from a previous list call.")]
        public string Page { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Fetches all pages of results.", ParameterSetName = AllPageSet)]
        public SwitchParameter All { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            ListTypesRequest request;

            try
            {
                request = new ListTypesRequest
                {
                    CatalogId = CatalogId,
                    Name = Name,
                    LifecycleState = LifecycleState,
                    IsInternal = IsInternal,
                    IsTag = IsTag,
                    IsApproved = IsApproved,
                    ExternalTypeName = ExternalTypeName,
                    TypeCategory = TypeCategory,
                    Fields = Fields,
                    SortBy = SortBy,
                    SortOrder = SortOrder,
                    Limit = Limit,
                    Page = Page,
                    OpcRequestId = OpcRequestId
                };
                IEnumerable<ListTypesResponse> responses = GetRequestDelegate().Invoke(request);
                foreach (var item in responses)
                {
                    response = item;
                    WriteOutput(response, response.TypeCollection, true);
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
            IEnumerable<ListTypesResponse> DefaultRequest(ListTypesRequest request) => Enumerable.Repeat(client.ListTypes(request).GetAwaiter().GetResult(), 1);
            if (ParameterSetName.Equals(AllPageSet))
            {
                return req => client.Paginators.ListTypesResponseEnumerator(req);
            }
            return DefaultRequest;
        }

        private ListTypesResponse response;
        private delegate IEnumerable<ListTypesResponse> RequestDelegate(ListTypesRequest request);
        private const string AllPageSet = "AllPages";
        private const string LimitSet = "Limit";
    }
}
