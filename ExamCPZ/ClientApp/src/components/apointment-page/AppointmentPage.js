import { useEffect, useState } from "react";
import AppointmentService from "../../services/AppointmentService";
import PatientService from "../../services/PatientService";
import Form from "./Form";
import Table from "./Table";

const INITIAL_DATA = {

};

const AppointmentPage = () => {
    const [data, setData] = useState([]);
    const [showForm, setShowForm] = useState(false);
    const [isEdit, setIsEdit] = useState(false);
    const [item, setItem] = useState(INITIAL_DATA);
    const [needUpdate, setNeedUpdate] = useState(true);
    const [patients, setPatients] = useState([]);
  
    useEffect(() => {
      if(needUpdate) {
        AppointmentService.getAll()
        .then((data) => setData(data))
        .catch((error) => alert(error))
  
        PatientService.getAll()
        .then(data => setPatients(data))
        .then(() => console.log('loaded'))
        .catch((error) => alert(error))

        console.log('update');

        setNeedUpdate(false);
      }
    }, [needUpdate])
  
    
    const handleEdit = async (id) => {
      await AppointmentService.getById(id)
      .then(data => setItem(data))
      .catch((error) => alert(error) )
  
      setIsEdit(true);
      setShowForm(true); 
    }
  
    const handleDelete = (id) => {
        AppointmentService.delete(id)
      .then(() => alert("Delete success"))
      .then(() => setNeedUpdate(true))
      .catch((error) => alert(error) )
    }
  
    const handleCancel = () => { 
      setIsEdit(false);
      setItem(INITIAL_DATA); 
      setShowForm(false); 
    };
  
    const handleSubmit = (data) => { 
      if(isEdit) {
        AppointmentService.update(data.id, data)
        .then(() => alert("Edit success"))
        .then(() => setNeedUpdate(true))
        .catch((error) => alert(error) )
      } else {
        AppointmentService.create(data)
        .then(() => alert("Add success"))
        .then(() => setNeedUpdate(true))
        .catch((error) => console.log(error) )
      }
  
      setIsEdit(false);
      setItem(INITIAL_DATA); 
      setShowForm(false); 
    };
  
    const handleCreate = () => {
      setIsEdit(false);
      setItem(INITIAL_DATA);
      setShowForm(true);
    }
  
    return (
      <>
        <button className='btn btn-outline-primary text-uppercase' onClick={handleCreate}>Create new</button>
        {showForm === true ?
          <Form data={item} patients={patients} onSubmit={handleSubmit} onCancel={handleCancel}/>
          : 
          <Table data={data} handleEdit={handleEdit} handleDelete={handleDelete}/>
        }
      </>
    );
}

export default AppointmentPage