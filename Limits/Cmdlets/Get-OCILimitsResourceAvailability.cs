/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.LimitsService.Requests;
using Oci.LimitsService.Responses;
using Oci.LimitsService.Models;

namespace Oci.LimitsService.Cmdlets
{
    [Cmdlet("Get", "OCILimitsResourceAvailability")]
    [OutputType(new System.Type[] { typeof(Oci.LimitsService.Models.ResourceAvailability), typeof(Oci.LimitsService.Responses.GetResourceAvailabilityResponse) })]
    public class GetOCILimitsResourceAvailability : OCILimitsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The service name of the target quota.")]
        public string ServiceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The limit name for which to fetch the data.")]
        public string LimitName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the compartment for which data is being fetched.")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"This field is mandatory if the scopeType of the target resource limit is AD. Otherwise, this field should be omitted. If the above requirements are not met, the API will return a 400 - InvalidParameter response.")]
        public string AvailabilityDomain { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetResourceAvailabilityRequest request;

            try
            {
                request = new GetResourceAvailabilityRequest
                {
                    ServiceName = ServiceName,
                    LimitName = LimitName,
                    CompartmentId = CompartmentId,
                    AvailabilityDomain = AvailabilityDomain,
                    OpcRequestId = OpcRequestId
                };

                response = client.GetResourceAvailability(request).GetAwaiter().GetResult();
                WriteOutput(response, response.ResourceAvailability);
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

        private GetResourceAvailabilityResponse response;
    }
}
