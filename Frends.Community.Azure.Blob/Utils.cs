﻿using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;

namespace Frends.Community.Azure.Blob
{
    public class Utils
    {
        public static CloudBlobContainer GetBlobContainer(string connectionString, string containerName)
        {
            // initialize azure account
            CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);

            // initialize blob client
            CloudBlobClient client = account.CreateCloudBlobClient();
            
            return client.GetContainerReference(containerName);
        }

        public static CloudBlob GetCloudBlob(CloudBlobContainer container, string blobName, AzureBlobType blobType)
        {
            CloudBlob cloudBlob;

            switch (blobType)
            {
                case AzureBlobType.Append:
                    cloudBlob = container.GetAppendBlobReference(blobName);
                    break;
                case AzureBlobType.Block:
                    cloudBlob = container.GetBlockBlobReference(blobName);
                    break;
                case AzureBlobType.Page:
                    cloudBlob = container.GetPageBlobReference(blobName);
                    break;
                default:
                    cloudBlob = container.GetBlockBlobReference(blobName);
                    break;
            }

            return cloudBlob;
        }
    }
}