import '../../App.css';
import React, { useState } from 'react';

function UploadFile() {
  const [file, setFile] = useState();
  const [uploadProgress, setUploadProgress] = useState(0);

  function handleChange(event) {
    setFile(event.target.files[0]);
  }

  function handleSubmit(event) {
    event.preventDefault();
    const url = 'https://localhost:7062/api/bankstatement/upload_swedbank_list';
    const formData = new FormData();
    formData.append('file', file);

    const xhr = new XMLHttpRequest();
    xhr.upload.addEventListener("progress", event => {
      if (event.lengthComputable) {
          const percentComplete = (event.loaded / event.total) * 100;
          setUploadProgress(percentComplete);
      }
  });

  xhr.addEventListener("load", () => {
      // Handle successful upload
      console.log(xhr.responseText);
  });

  xhr.addEventListener("error", () => {
      // Handle upload error
      console.error('Error uploading file:', xhr.statusText);
  });

  // Open and send the request
  xhr.open("POST", url);
  xhr.send(formData);
  }

  return (
    <div className='container left'>
      <form onSubmit={handleSubmit}>
        <h1>Upload swedbank statement</h1>
        <input type="file" onChange={handleChange} />
        <button type="submit">Upload</button>
        <progress value={uploadProgress} max="100"></progress>
      </form>
    </div>
  );
}

export default UploadFile;