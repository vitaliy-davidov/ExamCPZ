import { useForm } from "react-hook-form";


const Form = (props) => {
    const {onSubmit, onCancel, data={id: 0}, ...rest} = props;
    const {register, handleSubmit} = useForm({defaultValues: data})

    return(
        <form onSubmit={handleSubmit(onSubmit)} {...rest}>
            <div class="form-group row">
              <label htmlFor="input" class="col-sm-2 col-form-label">Name</label>
              <div class="col-sm-10">
                <input type="text" class="form-control" placeholder="Enter Name" {...register("name")}/>
              </div>
            </div>
            
            <div class="form-group row">
              <label htmlFor="input" class="col-sm-2 col-form-label">Birthday</label>
              <div class="col-sm-10">
                <input type="datetime-local" class="form-control" placeholder="Enter Birthday" {...register("birthday")}/>
              </div>
            </div>
            
            <div class="form-group row">
              <label htmlFor="input" class="col-sm-2 col-form-label">OwnerName</label>
              <div class="col-sm-10">
                <input type="text" class="form-control" placeholder="Enter OwnerName" {...register("ownerName")}/>
              </div>
            </div>
            
            <div class="form-group row">
              <label htmlFor="input" class="col-sm-2 col-form-label">OwnerSurname</label>
              <div class="col-sm-10">
                <input type="text" class="form-control" placeholder="Enter OwnerSurame" {...register("ownerSurname")}/>
              </div>
            </div>
            
            <div class="form-group row">
              <label htmlFor="input" class="col-sm-2 col-form-label">Diagnosis</label>
              <div class="col-sm-10">
                <input type="text" class="form-control" placeholder="Enter Diagnosis" {...register("diagnosis")}/>
              </div>
            </div>

            <input className="btn btn-outline-success text-uppercase" type={"submit"} onClick={onSubmit} value={"Submit"}/> 
            <input className="btn btn-outline-warning text-uppercase" type={"submit"} onClick={onCancel} value={"Cancel"}/> 
        </form>
    );
}

export default Form;