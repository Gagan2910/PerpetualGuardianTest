import React, {useState, useRef } from 'react';

export default function App(){
	const [selectedFile, setSelectedFile] = useState();
	const [isSelected, setIsSelected] = useState(false);

  const inputRef = useRef(null);

	const changeHandler = (event) => {
		setSelectedFile(event.target.files[0]);
		setIsSelected(true);
	};

	const handleSubmission = () => {
    const formData = new FormData();
		formData.append('File', selectedFile);

		fetch(
			'https://localhost:44373/api/UploadFilesDbs',
			{
				method: 'POST',
				body: formData,
			}
		)
			.then((response) => response.json())
			.then((result) => {
				console.log('Success:', result);
			})
			.catch((error) => {
				console.error('Error:', error);
			});
	};

  const handleClick=()=>
  {
    inputRef.current.click();
  }
  
  const tablestyle = {
    border: "1px solid black",
    borderCollapse: "collapse"
  };
	return(
   <div>
      <div onClick={handleClick} style={{textAlign:"center", width:"800px", padding:"50px", margin:"auto", marginTop:"30px", border: "3px solid black"}}>
        <h5>Browse for files</h5>
        <h5>(or drag and drop files)</h5>
			<input ref={inputRef} type="file" name="file" style={{display:"none"}} onChange={changeHandler} multiple/>
      </div>
			{isSelected ? 
      <table style={{textAlign:"center", width:"800px", padding:"50px", margin:"auto", marginTop:"30px",border: "3px solid black", borderCollapse:"collapse"}}>
      <tr>
     <th style={tablestyle}>FileName</th>
     <th style={tablestyle}>Uploaded Date</th> 
     </tr> 
     <tr>
    <td style={tablestyle}>{selectedFile.name}</td>
    <td style={tablestyle}>{selectedFile.lastModifiedDate.toLocaleString()}</td>
  </tr>
  </table>:" "}
		</div>
	)
}