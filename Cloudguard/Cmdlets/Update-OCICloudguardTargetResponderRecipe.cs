/*
 * NOTE: Generated using OracleSDKGenerator, API Version: 20200131
 * DO NOT EDIT this file manually.
 *
 * Copyright (c) 2020, Oracle and/or its affiliates.
 * This software is dual-licensed to you under the Universal Permissive License (UPL) 1.0 as shown at https://oss.oracle.com/licenses/upl or Apache License 2.0 as shown at http://www.apache.org/licenses/LICENSE-2.0. You may choose either license.
 */

using System;
using System.Management.Automation;
using Oci.CloudguardService.Requests;
using Oci.CloudguardService.Responses;
using Oci.CloudguardService.Models;

namespace Oci.CloudguardService.Cmdlets
{
    [Cmdlet("Update", "OCICloudguardTargetResponderRecipe")]
    [OutputType(new System.Type[] { typeof(Oci.CloudguardService.Models.TargetResponderRecipe), typeof(Oci.CloudguardService.Responses.UpdateTargetResponderRecipeResponse) })]
    public class UpdateOCICloudguardTargetResponderRecipe : OCICloudGuardCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"OCID of target")]
        public string TargetId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"OCID of TargetResponderRecipe")]
        public string TargetResponderRecipeId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The details to be updated.")]
        public UpdateTargetResponderRecipeDetails UpdateTargetResponderRecipeDetails { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"For optimistic concurrency control. In the PUT or DELETE call for a resource, set the `if-match` parameter to the value of the etag from a previous GET or POST response for that resource. The resource will be updated or deleted only if the etag you provide matches the resource's current etag value.")]
        public string IfMatch { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UpdateTargetResponderRecipeRequest request;

            try
            {
                request = new UpdateTargetResponderRecipeRequest
                {
                    TargetId = TargetId,
                    TargetResponderRecipeId = TargetResponderRecipeId,
                    UpdateTargetResponderRecipeDetails = UpdateTargetResponderRecipeDetails,
                    IfMatch = IfMatch,
                    OpcRequestId = OpcRequestId
                };

                response = client.UpdateTargetResponderRecipe(request).GetAwaiter().GetResult();
                WriteOutput(response, response.TargetResponderRecipe);
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

        private UpdateTargetResponderRecipeResponse response;
    }
}
