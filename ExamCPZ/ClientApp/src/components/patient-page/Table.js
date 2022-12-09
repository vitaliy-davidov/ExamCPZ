const Table = (props) => {
    const {data, handleEdit, handleDelete, ...rest} = props

    return (
    <table className='table table-striped' {...rest}>
        <thead>
          <tr>
            <th>Name</th>
            <th>Birthday</th>
            <th>OwnerName</th>
            <th>OwnerSurname</th>
            <th>Diagnosis</th>
            <th>Options</th>
          </tr>
        </thead>
        <tbody>
          {data.map(item =>
            <tr key={item.id}>
              <td>{item.name}</td>
              <td>{item.birthday}</td>
              <td>{item.ownerName}</td>
              <td>{item.ownerSurname}</td>
              <td>{item.diagnosis}</td>
              <td>
                <button className="btn btn-outline-warning text-uppercase me-3" onClick={() => {handleEdit(item.id)}}>Edit</button>
                <button className="btn btn-outline-danger text-uppercase" onClick={() => {handleDelete(item.id)}}>Delete</button>
              </td>
            </tr>
          )}
        </tbody>
      </table>
    );
}

export default Table