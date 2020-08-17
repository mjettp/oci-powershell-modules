/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20170115
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.LoadbalancerService.Requests;
using Oci.LoadbalancerService.Responses;
using Oci.LoadbalancerService.Models;

namespace Oci.LoadbalancerService.Cmdlets
{
    [Cmdlet("Update", "OCILoadbalancerHealthChecker")]
    [OutputType(new System.Type[] { typeof(Oci.PSModules.Common.Cmdlets.WorkRequest), typeof(Oci.LoadbalancerService.Responses.UpdateHealthCheckerResponse) })]
    public class UpdateOCILoadbalancerHealthChecker : OCILoadBalancerCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The health check policy configuration details.")]
        public UpdateHealthCheckerDetails HealthChecker { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The [OCID](https://docs.cloud.oracle.com/Content/General/Concepts/identifiers.htm) of the load balancer associated with the health check policy to be updated.")]
        public string LoadBalancerId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the backend set associated with the health check policy to be retrieved.

Example: `example_backend_set`")]
        public string BackendSetName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The unique Oracle-assigned identifier for the request. If you need to contact Oracle about a particular request, please provide the request ID.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations (e.g., if a resource has been deleted and purged from the system, then a retry of the original creation request may be rejected).")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateHealthCheckerRequest request;

            try
            {
                request = new UpdateHealthCheckerRequest
                {
                    HealthChecker = HealthChecker,
                    LoadBalancerId = LoadBalancerId,
                    BackendSetName = BackendSetName,
                    OpcRequestId = OpcRequestId,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.UpdateHealthChecker(request).GetAwaiter().GetResult();
                WriteOutput(response, CreateWorkRequestObject(response.OpcWorkRequestId));
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

        private UpdateHealthCheckerResponse response;
    }
}
