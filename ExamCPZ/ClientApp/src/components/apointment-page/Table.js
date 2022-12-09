const Table = (props) => {
    const {data, handleEdit, handleDelete, ...rest} = props

    return (
    <table className='table table-striped' {...rest}>
        <thead>
          <tr>
            <th>Date</th>
            <th>Patient</th>
            <th>Options</th>
          </tr>
        </thead>
        <tbody>
          {data.map(item =>
            <tr key={item.id}>
              <td>{item.date}</td>
              <td>{item.patient.name}</td>
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