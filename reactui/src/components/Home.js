import React from 'react'

export default function Home() {
  return (
    <div className='container-fluid'>
      <h1 className='text-center'>HOME</h1>
      <div className='container'>
        <ul className="list-group">Build:
          <li>CSV Parser</li>
          <li>Interactive table to sort out data</li>
          <li>Table pagination  <a href="https://henriquesd.medium.com/pagination-in-a-net-web-api-with-ef-core-2e6cb032afb7">Pagination tutorial</a></li>
          <li>Make sure you cannot upload duplicate data</li>
        </ul>
      </div>
    </div>
  )
}
