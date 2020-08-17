/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20160918
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.IdentityService.Requests;
using Oci.IdentityService.Responses;
using Oci.IdentityService.Models;

namespace Oci.IdentityService.Cmdlets
{
    [Cmdlet("Invoke", "OCIIdentityAssembleEffectiveTagSet")]
    [OutputType(new System.Type[] { typeof(Oci.IdentityService.Models.TagDefaultSummary), typeof(Oci.IdentityService.Responses.AssembleEffectiveTagSetResponse) })]
    public class InvokeOCIIdentityAssembleEffectiveTagSet : OCIIdentityCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The OCID of the compartment (remember that the tenancy is simply the root compartment).")]
        public string CompartmentId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A filter to only return resources that match the given lifecycle state.  The state value is case-insensitive.")]
        public System.Nullable<Oci.IdentityService.Models.TagDefaultSummary.LifecycleStateEnum> LifecycleState { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            AssembleEffectiveTagSetRequest request;

            try
            {
                request = new AssembleEffectiveTagSetRequest
                {
                    CompartmentId = CompartmentId,
                    LifecycleState = LifecycleState
                };

                response = client.AssembleEffectiveTagSet(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Items);
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

        private AssembleEffectiveTagSetResponse response;
    }
}
