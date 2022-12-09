import { useForm } from "react-hook-form";


const Form = (props) => {
    const {onSubmit, onCancel, data={id: 0}, patients=[], ...rest} = props;
    const {register, handleSubmit} = useForm({defaultValues: data})

    return(
        <form onSubmit={handleSubmit(onSubmit)} {...rest}>           
            <div class="form-group row">
              <label htmlFor="input" class="col-sm-2 col-form-label">Date</label>
              <div class="col-sm-10">
                <input type={"datetime-local"} class="form-control" placeholder="Enter Birthday" {...register("date")}/>
              </div>
            </div>
            
            <div class="form-group row">
              <label htmlFor="input" class="col-sm-2 col-form-label">Patient</label>
              <div class="col-sm-10">
                <select class="form-control" {...register("patientId")}>
                    {
                      patients.map(patient => <option value={patient.id}>{patient.name}</option>)
                    }
                </select>
              </div>
            </div>

            <input className="btn btn-outline-success text-uppercase" type={"submit"} onClick={onSubmit} value={"Submit"}/> 
            <input className="btn btn-outline-warning text-uppercase" type={"submit"} onClick={onCancel} value={"Cancel"}/> 
        </form>
    );
}

export default Form;