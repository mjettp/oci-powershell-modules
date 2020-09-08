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
    [Cmdlet("Write", "OCILoganalyticsLogFile")]
    [OutputType(new System.Type[] { typeof(Oci.LoganalyticsService.Models.Upload), typeof(Oci.LoganalyticsService.Responses.UploadLogFileResponse) })]
    public class WriteOCILoganalyticsLogFile : OCILogAnalyticsCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The Log Analytics namespace used for the request.")]
        public string NamespaceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the upload. This can be considered as a container name where different kind of logs will be collected and searched together. This upload name/id can further be used for retrieving the details of the upload, including its status or deleting the upload.")]
        public string UploadName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Name of the log source that will be used to process the files being uploaded.")]
        public string LogSourceName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The name of the file being uploaded. The extension of the filename part will be used to detect the type of file (like zip, tar).")]
        public string Filename { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"The log group OCID to which the log data in this upload will be mapped to.   Example: `ocid1.loganalyticsloggroup.oc1..aaaaaaaad3q4sosi5i7z7onw2kgbwyk1581620537198`")]
        public string OpcMetaLoggrpid { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Log data", ParameterSetName = FromStreamSet)]
        public System.IO.Stream UploadLogFileBody { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = @"Use this parameter to provide the file location from where the input stream to be read. Log data", ParameterSetName = FromFileSet)]
        public String UploadLogFileBodyFromFile { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The entity OCID.")]
        public string EntityId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Timezone to be used when processing log entries whose timestamps do not include an explicit timezone. When this property is not specified, the timezone of the entity specified is used. If the entity is also not specified or do not have a valid timezone then UTC is used")]
        public string Timezone { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"character Encoding")]
        public string CharEncoding { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"This property is used to specify the format of the date. This is to be used for ambiguous dates like 12/11/10. This property can take any of the following values -  MONTH_DAY_YEAR, DAY_MONTH_YEAR, YEAR_MONTH_DAY, MONTH_DAY, DAY_MONTH.")]
        public string DateFormat { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"Used to indicate the year where the log entries timestamp do not mention year (Ex: Nov  8 20:45:56).")]
        public string DateYear { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"This property can be used to reset configuration cache in case of an issue with the upload.")]
        public System.Nullable<bool> InvalidateCache { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The client request ID for tracing.")]
        public string OpcRequestId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The base-64 encoded MD5 hash of the body. If the Content-MD5 header is present, Log Analytics performs an integrity check on the body of the HTTP request by computing the MD5 hash for the body and comparing it to the MD5 hash supplied in the header. If the two hashes do not match, the log data is rejected and an HTTP-400 Unmatched Content MD5 error is returned with the message:

""The computed MD5 of the request body (ACTUAL_MD5) does not match the Content-MD5 header (HEADER_MD5)""")]
        public string ContentMd5 { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"The content type of the log data. Defaults to 'application/octet-stream' if not overridden during the UploadLogFile call.")]
        public string ContentType { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = @"A token that uniquely identifies a request so it can be retried in case of a timeout or server error without risk of executing that same action again. Retry tokens expire after 24 hours, but can be invalidated before then due to conflicting operations. For example, if a resource has been deleted and purged from the system, then a retry of the original creation request might be rejected.")]
        public string OpcRetryToken { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            UploadLogFileRequest request;

            if (ParameterSetName.Equals(FromFileSet))
            {
                UploadLogFileBody = System.IO.File.OpenRead(GetAbsoluteFilePath(UploadLogFileBodyFromFile));
            }
            

            try
            {
                request = new UploadLogFileRequest
                {
                    NamespaceName = NamespaceName,
                    UploadName = UploadName,
                    LogSourceName = LogSourceName,
                    Filename = Filename,
                    OpcMetaLoggrpid = OpcMetaLoggrpid,
                    UploadLogFileBody = UploadLogFileBody,
                    EntityId = EntityId,
                    Timezone = Timezone,
                    CharEncoding = CharEncoding,
                    DateFormat = DateFormat,
                    DateYear = DateYear,
                    InvalidateCache = InvalidateCache,
                    OpcRequestId = OpcRequestId,
                    ContentMd5 = ContentMd5,
                    ContentType = ContentType,
                    OpcRetryToken = OpcRetryToken
                };

                response = client.UploadLogFile(request).GetAwaiter().GetResult();
                WriteOutput(response, response.Upload);
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

        private UploadLogFileResponse response;
        private const string FromFileSet = "FromFile";
        private const string FromStreamSet = "FromStream";
    }
}