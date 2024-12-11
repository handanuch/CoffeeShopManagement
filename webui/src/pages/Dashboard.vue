<template>
    <div
      style="max-height: 100vh; overflow-y: auto; overflow-x: hidden"
      data-simplebar="init"
      class="simplebar-wrapper"
    >
      <WideDiv>
        <div class="row">
          <div class="col-xl-4">
            <div class="card overflow-hidden card-bg-secondary">
              <div class="bg-primary bg-soft container-loginhearder">
                <div class="row">
                  <div class="col-7">
                    <div class="text-blue p-3">
                      <h5 class="text-red" style="color: blue">..</h5>
                      <p>.</p>
                    </div>
                  </div>
                  <div class="col-5 align-self-end">
                    <!-- <img
                      src="/src/assets/images/profile-img.png"
                      alt=""
                      class="img-fluid"
                    /> -->
                  </div>
                </div>
              </div>
              <div class="card-body pt-0">
                <div class="row">
                  <div class="col-sm-4">
                    <div class="avatar-xl profile-user-wid mb-0">
                    <img
                    src="@/assets/images/Logo.png" 
                     class="img-thumbnail avatar-lg"
                      />
                  </div>
                    <h5 class="font-size-15 text-truncate">IT Coffee</h5>
                    <p class="text-muted mb-0 text-truncate"></p>
                  </div>
  
                  <div class="col-sm-8">
                    <div class="pt-4">
                      <div class="row">
                        <div class="col-6">
                          <h5 class="font-size-15">125</h5>
                          <p class="text-muted mb-0">Items</p>
                        </div>
                        <div class="col-6">
                          <h5 class="font-size-15"></h5>
                          <p class="text-muted mb-0"></p>
                        </div>
                      </div>
                      
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div class="card card-bg-secondary">
              <div class="card-body">
                <h4 class="card-title mb-4">Monthly Income</h4>
                <div class="row">
                  <div class="col-sm-6">
                    <p class="text-muted">This month</p>
                    <h3>$34,252</h3>
                    <p class="text-muted">
                      <span class="text-success me-2">
                        12% <i class="mdi mdi-arrow-up"></i>
                      </span>
                      From previous period
                    </p>
  
                    <div class="mt-4">
                      <a
                        href="javascript: void(0);"
                        class="btn btn-primary waves-effect waves-light btn-sm"
                        >View More <i class="mdi mdi-arrow-right ms-1"></i
                      ></a>
                    </div>
                  </div>
                  <div class="col-sm-6">
                    <div class="mt-4 mt-sm-0">
                      <div id="radialBar-chart" class="apex-charts"></div>
                    </div>
                  </div>
                </div>
                <p class="text-muted mb-0">
                  We craft digital, graphic and dimensional thinking.
                </p>
              </div>
            </div>
          </div>
          <div class="col-xl-8">
            <div class="row">
              <div class="col-md-4">
                <div class="card mini-stats-wid card-bg-secondary">
                  <div class="card-body">
                    <div class="d-flex">
                      <div class="flex-grow-1">
                        <p class="text-muted fw-medium">Orders</p>
                        <h4 class="mb-0">1,235</h4>
                      </div>
  
                      <div class="flex-shrink-0 align-self-center">
                        <div
                          class="mini-stat-icon avatar-sm rounded-circle bg-primary"
                        >
                          <span class="avatar-title">
                            <i class="bx bx-copy-alt font-size-24"></i>
                          </span>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-4">
                <div class="card mini-stats-wid card-bg-secondary">
                  <div class="card-body">
                    <div class="d-flex">
                      <div class="flex-grow-1">
                        <p class="text-muted fw-medium">Revenue</p>
                        <h4 class="mb-0">$3, 723</h4>
                      </div>
  
                      <div class="flex-shrink-0 align-self-center">
                        <div
                          class="avatar-sm rounded-circle bg-primary mini-stat-icon"
                        >
                          <span class="avatar-title rounded-circle bg-primary">
                            <i class="bx bx-archive-in font-size-24"></i>
                          </span>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="col-md-4">
                <div class="card mini-stats-wid card-bg-secondary">
                  <div class="card-body">
                    <div class="d-flex">
                      <div class="flex-grow-1">
                        <p class="text-muted fw-medium">Popular</p>
                        <h4 class="mb-0">IT Coffee Latte</h4>
                      </div>
  
                      <div class="flex-shrink-0 align-self-center">
                        <div
                          class="avatar-sm rounded-circle bg-primary mini-stat-icon"
                        >
                          <span class="avatar-title rounded-circle bg-primary">
                            <i class="bx bx-purchase-tag-alt font-size-24"></i>
                          </span>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <!-- end row -->
  
            <div class="card card-bg-secondary">
              <div class="card-body">
                <div class="d-sm-flex flex-wrap">
                  <h4 class="card-title mb-4">Order Table</h4>
                  <div class="ms-auto">
                    <ul class="nav nav-pills">
                      <li class="nav-item">
                        <a class="nav-link active" href="#">Week</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" href="#">Month</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" href="#">Year</a>
                      </li>
                    </ul>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-12">
                    <div ref="BarSwicth" style="width: 100%; height: 365px">
                        <div class="row">
          <div class="col-lg-12">
            <div class="card card-bg-secondary">
              <div class="card-body">
               
                <div class="table-responsive">
                  <table class="table align-middle table-nowrap mb-0">
                    <thead class="table-light">
                      <tr>
                        <th style="width: 20px">
                          <div class="form-check font-size-16 align-middle">
                            <input
                              class="form-check-input"
                              type="checkbox"
                              id="transactionCheck01"
                            />
                            <label
                              class="form-check-label"
                              for="transactionCheck01"
                            ></label>
                          </div>
                        </th>
                        <th class="align-middle">Invoice ID</th>
                        <th class="align-middle">Items</th>
                        <th class="align-middle">Date</th>
                        <th class="align-middle">Total</th>
                        <th class="align-middle">View Details</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <td>
                          <div class="form-check font-size-16">
                            <input
                              class="form-check-input"
                              type="checkbox"
                              id="transactionCheck02"
                            />
                            <label
                              class="form-check-label"
                              for="transactionCheck02"
                            ></label>
                          </div>
                        </td>
                        <td>
                          <a href="javascript: void(0);" class="text-body fw-bold"
                            >0001</a
                          >
                        </td>
                        <td>Ice Late</td>
                        <td>01 Mar, 2024</td>
                        <td>$2</td>
                        
                        <td>
                          <!-- Button trigger modal -->
                          <button
                            type="button"
                            class="btn btn-primary btn-sm btn-rounded waves-effect waves-light"
                            data-bs-toggle="modal"
                            data-bs-target=".transaction-detailModal"
                          >
                            View Details
                          </button>
                        </td>
                      </tr>
  
                      <tr>
                        <td>
                          <div class="form-check font-size-16">
                            <input
                              class="form-check-input"
                              type="checkbox"
                              id="transactionCheck03"
                            />
                            <label
                              class="form-check-label"
                              for="transactionCheck03"
                            ></label>
                          </div>
                        </td>
                        <td>
                          <a href="javascript: void(0);" class="text-body fw-bold"
                            >0002</a
                          >
                        </td>
                        <td>Ice Late</td>
                        <td>01 Mar, 2024</td>
                        <td>$2</td>
                        
                        <td>
                          <!-- Button trigger modal -->
                          <button
                            type="button"
                            class="btn btn-primary btn-sm btn-rounded waves-effect waves-light"
                            data-bs-toggle="modal"
                            data-bs-target=".transaction-detailModal"
                          >
                            View Details
                          </button>
                        </td>
                      </tr>
  
                      <tr>
                        <td>
                          <div class="form-check font-size-16">
                            <input
                              class="form-check-input"
                              type="checkbox"
                              id="transactionCheck04"
                            />
                            <label
                              class="form-check-label"
                              for="transactionCheck04"
                            ></label>
                          </div>
                        </td>
                        <td>
                          <a href="javascript: void(0);" class="text-body fw-bold"
                            >0003</a
                          >
                        </td>
                        <td>Ice Late</td>
                        <td>01 Mar, 2024</td>
                        <td>$2</td>
                        
                        <td>
                          <!-- Button trigger modal -->
                          <button
                            type="button"
                            class="btn btn-primary btn-sm btn-rounded waves-effect waves-light"
                            data-bs-toggle="modal"
                            data-bs-target=".transaction-detailModal"
                          >
                            View Details
                          </button>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <div class="form-check font-size-16">
                            <input
                              class="form-check-input"
                              type="checkbox"
                              id="transactionCheck05"
                            />
                            <label
                              class="form-check-label"
                              for="transactionCheck05"
                            ></label>
                          </div>
                        </td>
                        <td>
                          <a href="javascript: void(0);" class="text-body fw-bold"
                            >0004</a
                          >
                        </td>
                        <td>Ice Late</td>
                        <td>01 Mar, 2024</td>
                        <td>$2</td>
                        
                        <td>
                          <!-- Button trigger modal -->
                          <button
                            type="button"
                            class="btn btn-primary btn-sm btn-rounded waves-effect waves-light"
                            data-bs-toggle="modal"
                            data-bs-target=".transaction-detailModal"
                          >
                            View Details
                          </button>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <div class="form-check font-size-16">
                            <input
                              class="form-check-input"
                              type="checkbox"
                              id="transactionCheck06"
                            />
                            <label
                              class="form-check-label"
                              for="transactionCheck06"
                            ></label>
                          </div>
                        </td>
                        <td>
                          <a href="javascript: void(0);" class="text-body fw-bold"
                            >0005</a
                          >
                        </td>
                        <td>Ice Late</td>
                        <td>01 Mar, 2024</td>
                        <td>$2</td>
                        
                        <td>
                          <!-- Button trigger modal -->
                          <button
                            type="button"
                            class="btn btn-primary btn-sm btn-rounded waves-effect waves-light"
                            data-bs-toggle="modal"
                            data-bs-target=".transaction-detailModal"
                          >
                            View Details
                          </button>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <div class="form-check font-size-16">
                            <input
                              class="form-check-input"
                              type="checkbox"
                              id="transactionCheck07"
                            />
                            <label
                              class="form-check-label"
                              for="transactionCheck07"
                            ></label>
                          </div>
                        </td>
                        <td>
                          <a href="javascript: void(0);" class="text-body fw-bold"
                            >0006</a
                          >
                        </td>
                        <td>Ice Late</td>
                        <td>01 Mar, 2024</td>
                        <td>$2</td>
                        
                        <td>
                          <!-- Button trigger modal -->
                          <button
                            type="button"
                            class="btn btn-primary btn-sm btn-rounded waves-effect waves-light"
                            data-bs-toggle="modal"
                            data-bs-target=".transaction-detailModal"
                          >
                            View Details
                          </button>
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
                <!-- end table-responsive -->
              </div>
            </div>
          </div>
        </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- end row -->
        <div class="row">
          <div class="col-lg-12">
            <div class="card card-bg-secondary">
              <div class="card-body">
                <h4 class="card-title mb-4">Latest Transaction</h4>
                <div class="table-responsive">
                  <table class="table align-middle table-nowrap mb-0">
                    <thead class="table-light">
                      <tr>
                        <th style="width: 20px">
                          <div class="form-check font-size-16 align-middle">
                            <input
                              class="form-check-input"
                              type="checkbox"
                              id="transactionCheck01"
                            />
                            <label
                              class="form-check-label"
                              for="transactionCheck01"
                            ></label>
                          </div>
                        </th>
                        <th class="align-middle">Invoice Id</th>
                        <th class="align-middle">Item name</th>
                        <th class="align-middle">Date</th>
                        <th class="align-middle">Total</th>
                        <th class="align-middle">Payment Status</th>
                        <th class="align-middle">Payment Method</th>
                        <th class="align-middle">View Details</th>
                      </tr>
                    </thead>
                    <tbody>
                      <tr>
                        <td>
                          <div class="form-check font-size-16">
                            <input
                              class="form-check-input"
                              type="checkbox"
                              id="transactionCheck02"
                            />
                            <label
                              class="form-check-label"
                              for="transactionCheck02"
                            ></label>
                          </div>
                        </td>
                        <td>
                          <a href="javascript: void(0);" class="text-body fw-bold"
                            >00001</a
                          >
                        </td>
                        <td>Ice Late</td>
                        <td>07 Oct, 2024</td>
                        <td>$2</td>
                        <td>
                          <span
                            class="badge badge-pill badge-soft-success font-size-11"
                            >Paid</span
                          >
                        </td>
                        <td>
                          <i class="fab fa-cc-mastercard me-1"></i> Mastercard
                        </td>
                        <td>
                          <!-- Button trigger modal -->
                          <button
                            type="button"
                            class="btn btn-primary btn-sm btn-rounded waves-effect waves-light"
                            data-bs-toggle="modal"
                            data-bs-target=".transaction-detailModal"
                          >
                            View Details
                          </button>
                        </td>
                      </tr>
  
                      <tr>
                        <td>
                          <div class="form-check font-size-16">
                            <input
                              class="form-check-input"
                              type="checkbox"
                              id="transactionCheck03"
                            />
                            <label
                              class="form-check-label"
                              for="transactionCheck03"
                            ></label>
                          </div>
                        </td>
                        <td>
                          <a href="javascript: void(0);" class="text-body fw-bold"
                            >00002</a
                          >
                        </td>
                        <td>Hot Late</td>
                        <td>07 Oct, 2024</td>
                        <td>$2</td>
                        <td>
                          <span
                            class="badge badge-pill badge-soft-danger font-size-11"
                            >Chargeback</span
                          >
                        </td>
                        <td><i class="fab fa-cc-visa me-1"></i> Visa</td>
                        <td>
                          <!-- Button trigger modal -->
                          <button
                            type="button"
                            class="btn btn-primary btn-sm btn-rounded waves-effect waves-light"
                            data-bs-toggle="modal"
                            data-bs-target=".transaction-detailModal"
                          >
                            View Details
                          </button>
                        </td>
                      </tr>
  
                      <tr>
                        <td>
                          <div class="form-check font-size-16">
                            <input
                              class="form-check-input"
                              type="checkbox"
                              id="transactionCheck04"
                            />
                            <label
                              class="form-check-label"
                              for="transactionCheck04"
                            ></label>
                          </div>
                        </td>
                        <td>
                          <a href="javascript: void(0);" class="text-body fw-bold"
                            >00003</a
                          >
                        </td>
                        <td>Ice Late</td>
                        <td>06 Oct, 2024</td>
                        <td>$2</td>
                        <td>
                          <span
                            class="badge badge-pill badge-soft-success font-size-11"
                            >Paid</span
                          >
                        </td>
                        <td><i class="fab fa-cc-paypal me-1"></i> Paypal</td>
                        <td>
                          <!-- Button trigger modal -->
                          <button
                            type="button"
                            class="btn btn-primary btn-sm btn-rounded waves-effect waves-light"
                            data-bs-toggle="modal"
                            data-bs-target=".transaction-detailModal"
                          >
                            View Details
                          </button>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <div class="form-check font-size-16">
                            <input
                              class="form-check-input"
                              type="checkbox"
                              id="transactionCheck05"
                            />
                            <label
                              class="form-check-label"
                              for="transactionCheck05"
                            ></label>
                          </div>
                        </td>
                        <td>
                          <a href="javascript: void(0);" class="text-body fw-bold"
                            >00004</a
                          >
                        </td>
                        <td>Ice Late</td>
                        <td>05 Oct, 2024</td>
                        <td>$2</td>
                        <td>
                          <span
                            class="badge badge-pill badge-soft-success font-size-11"
                            >Paid</span
                          >
                        </td>
                        <td>
                          <i class="fab fa-cc-mastercard me-1"></i> Mastercard
                        </td>
                        <td>
                          <!-- Button trigger modal -->
                          <button
                            type="button"
                            class="btn btn-primary btn-sm btn-rounded waves-effect waves-light"
                            data-bs-toggle="modal"
                            data-bs-target=".transaction-detailModal"
                          >
                            View Details
                          </button>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <div class="form-check font-size-16">
                            <input
                              class="form-check-input"
                              type="checkbox"
                              id="transactionCheck06"
                            />
                            <label
                              class="form-check-label"
                              for="transactionCheck06"
                            ></label>
                          </div>
                        </td>
                        <td>
                          <a href="javascript: void(0);" class="text-body fw-bold"
                            >00005</a
                          >
                        </td>
                        <td>Ice Late</td>
                        <td>04 Oct, 2024</td>
                        <td>$2</td>
                        <td>
                          <span
                            class="badge badge-pill badge-soft-warning font-size-11"
                            >Refund</span
                          >
                        </td>
                        <td><i class="fab fa-cc-visa me-1"></i> Visa</td>
                        <td>
                          <!-- Button trigger modal -->
                          <button
                            type="button"
                            class="btn btn-primary btn-sm btn-rounded waves-effect waves-light"
                            data-bs-toggle="modal"
                            data-bs-target=".transaction-detailModal"
                          >
                            View Details
                          </button>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <div class="form-check font-size-16">
                            <input
                              class="form-check-input"
                              type="checkbox"
                              id="transactionCheck07"
                            />
                            <label
                              class="form-check-label"
                              for="transactionCheck07"
                            ></label>
                          </div>
                        </td>
                        <td>
                          <a href="javascript: void(0);" class="text-body fw-bold"
                            >#SK2545</a
                          >
                        </td>
                        <td>Jacob Hunter</td>
                        <td>04 Oct, 2019</td>
                        <td>$392</td>
                        <td>
                          <span
                            class="badge badge-pill badge-soft-success font-size-11"
                            >Paid</span
                          >
                        </td>
                        <td><i class="fab fa-cc-paypal me-1"></i> Paypal</td>
                        <td>
                          <!-- Button trigger modal -->
                          <button
                            type="button"
                            class="btn btn-primary btn-sm btn-rounded waves-effect waves-light"
                            data-bs-toggle="modal"
                            data-bs-target=".transaction-detailModal"
                          >
                            View Details
                          </button>
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
                <!-- end table-responsive -->
              </div>
            </div>
          </div>
        </div>
        <div class="row">
          <div class="col-xl-4">
            <div class="card card-bg-secondary">
              <div class="card-body">
                <h4 class="card-title mb-4">Social Source</h4>
                <div class="text-center">
                  <div class="avatar-sm mx-auto mb-4">
                    <span
                      class="avatar-title rounded-circle bg-primary bg-soft font-size-24"
                    >
                      <i class="mdi mdi-facebook text-primary"></i>
                    </span>
                  </div>
                  <p class="font-16 text-muted mb-2"></p>
                  <h5>
                    <a href="javascript: void(0);" class="text-dark"
                      >Facebook -
                      <span class="text-muted font-16">125 sales</span>
                    </a>
                  </h5>
                  <p class="text-muted">
                    Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien
                    ut libero venenatis faucibus tincidunt.
                  </p>
                  <a href="javascript: void(0);" class="text-primary font-16"
                    >Learn more <i class="mdi mdi-chevron-right"></i
                  ></a>
                </div>
                <div class="row mt-4">
                  <div class="col-4">
                    <div class="social-source text-center mt-3">
                      <div class="avatar-xs mx-auto mb-3">
                        <span
                          class="avatar-title rounded-circle bg-primary font-size-16"
                        >
                          <i class="mdi mdi-facebook text-white"></i>
                        </span>
                      </div>
                      <h5 class="font-size-15">Facebook</h5>
                      <p class="text-muted mb-0">125 sales</p>
                    </div>
                  </div>
                  <div class="col-4">
                    <div class="social-source text-center mt-3">
                      <div class="avatar-xs mx-auto mb-3">
                        <span
                          class="avatar-title rounded-circle bg-info font-size-16"
                        >
                          <i class="mdi mdi-twitter text-white"></i>
                        </span>
                      </div>
                      <h5 class="font-size-15">Twitter</h5>
                      <p class="text-muted mb-0">112 sales</p>
                    </div>
                  </div>
                  <div class="col-4">
                    <div class="social-source text-center mt-3">
                      <div class="avatar-xs mx-auto mb-3">
                        <span
                          class="avatar-title rounded-circle bg-pink font-size-16"
                        >
                          <i class="mdi mdi-instagram text-white"></i>
                        </span>
                      </div>
                      <h5 class="font-size-15">Instagram</h5>
                      <p class="text-muted mb-0">104 sales</p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-xl-4">
            <div class="card card-bg-secondary">
              <div class="card-body">
                <h4 class="card-title mb-5">Activity</h4>
                <ul class="verti-timeline list-unstyled">
                  <li class="event-list">
                    <div class="event-timeline-dot">
                      <i class="bx bx-right-arrow-circle font-size-18"></i>
                    </div>
                    <div class="d-flex">
                      <div class="flex-shrink-0 me-3">
                        <h5 class="font-size-14">
                          22 Nov
                          <i
                            class="bx bx-right-arrow-alt font-size-16 text-primary align-middle ms-2"
                          ></i>
                        </h5>
                      </div>
                      <div class="flex-grow-1">
                        <div>Responded to need “Volunteer Activities</div>
                      </div>
                    </div>
                  </li>
                  <li class="event-list">
                    <div class="event-timeline-dot">
                      <i class="bx bx-right-arrow-circle font-size-18"></i>
                    </div>
                    <div class="d-flex">
                      <div class="flex-shrink-0 me-3">
                        <h5 class="font-size-14">
                          17 Nov
                          <i
                            class="bx bx-right-arrow-alt font-size-16 text-primary align-middle ms-2"
                          ></i>
                        </h5>
                      </div>
                      <div class="flex-grow-1">
                        <div>
                          Everyone realizes why a new common language would be
                          desirable...
                          <a href="javascript: void(0);">Read more</a>
                        </div>
                      </div>
                    </div>
                  </li>
                  <li class="event-list active">
                    <div class="event-timeline-dot">
                      <i
                        class="bx bxs-right-arrow-circle font-size-18 bx-fade-right"
                      ></i>
                    </div>
                    <div class="d-flex">
                      <div class="flex-shrink-0 me-3">
                        <h5 class="font-size-14">
                          15 Nov
                          <i
                            class="bx bx-right-arrow-alt font-size-16 text-primary align-middle ms-2"
                          ></i>
                        </h5>
                      </div>
                      <div class="flex-grow-1">
                        <div>Joined the group “Boardsmanship Forum”</div>
                      </div>
                    </div>
                  </li>
                  <li class="event-list">
                    <div class="event-timeline-dot">
                      <i class="bx bx-right-arrow-circle font-size-18"></i>
                    </div>
                    <div class="d-flex">
                      <div class="flex-shrink-0 me-3">
                        <h5 class="font-size-14">
                          12 Nov
                          <i
                            class="bx bx-right-arrow-alt font-size-16 text-primary align-middle ms-2"
                          ></i>
                        </h5>
                      </div>
                      <div class="flex-grow-1">
                        <div>Responded to need “In-Kind Opportunity”</div>
                      </div>
                    </div>
                  </li>
                </ul>
                <div class="text-center mt-4">
                  <a
                    href="javascript: void(0);"
                    class="btn btn-primary waves-effect waves-light btn-sm"
                    >View More <i class="mdi mdi-arrow-right ms-1"></i
                  ></a>
                </div>
              </div>
            </div>
          </div>
  
          <div class="col-xl-4">
            <div class="card">
              <div class="card-body">
                <h4 class="card-title mb-4">Top Cities Selling Product</h4>
  
                <div class="text-center">
                  <div class="mb-4">
                    <i class="bx bx-map-pin text-primary display-4"></i>
                  </div>
                  <h3>1,456</h3>
                  <p>San Francisco</p>
                </div>
  
                <div class="table-responsive mt-4">
                  <table class="table align-middle table-nowrap">
                    <tbody>
                      <tr>
                        <td style="width: 30%">
                          <p class="mb-0">San Francisco</p>
                        </td>
                        <td style="width: 25%">
                          <h5 class="mb-0">1,456</h5>
                        </td>
                        <td>
                          <div class="progress bg-transparent progress-sm">
                            <div
                              class="progress-bar bg-primary rounded"
                              role="progressbar"
                              style="width: 94%"
                              aria-valuenow="94"
                              aria-valuemin="0"
                              aria-valuemax="100"
                            ></div>
                          </div>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <p class="mb-0">Los Angeles</p>
                        </td>
                        <td>
                          <h5 class="mb-0">1,123</h5>
                        </td>
                        <td>
                          <div class="progress bg-transparent progress-sm">
                            <div
                              class="progress-bar bg-success rounded"
                              role="progressbar"
                              style="width: 82%"
                              aria-valuenow="82"
                              aria-valuemin="0"
                              aria-valuemax="100"
                            ></div>
                          </div>
                        </td>
                      </tr>
                      <tr>
                        <td>
                          <p class="mb-0">San Diego</p>
                        </td>
                        <td>
                          <h5 class="mb-0">1,026</h5>
                        </td>
                        <td>
                          <div class="progress bg-transparent progress-sm">
                            <div
                              class="progress-bar bg-warning rounded"
                              role="progressbar"
                              style="width: 70%"
                              aria-valuenow="70"
                              aria-valuemin="0"
                              aria-valuemax="100"
                            ></div>
                          </div>
                        </td>
                      </tr>
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- end row -->
  
        
  
        <div class="row">
          <div class="col-md-6 col-sm-6 col-gl-4 col-xs-12">
            <div ref="xchart" style="width: 100%; height: 300px"></div>
          </div>
          <div class="col-md-6 col-sm-6 col-gl-4 col-xs-12">
            <div ref="Barchart" style="width: 100%; height: 300px"></div>
          </div>
        </div>
  
        <!-- <WideDivTitle :title="t('branch')" :badge="$label" /> -->
      </WideDiv>
    </div>
  </template>
  
  <script setup>
  import { ref, computed, reactive, onMounted } from "vue";
  import { $api, $msg, $date } from "@/utils/helper";
  import { useI18n } from "vue-i18n";
  import lang from "./CustomerInfo.json";
  import useTabStore from "@/stores/tab";
  const $tab = useTabStore();
  const xchart = ref(null);
  const Barchart = ref(null);
  const BarSwicth = ref(null);
  const { t } = useI18n({ messages: lang });
</script>
<style scoped>
.container-loginhearder{
  background-image: url('@/assets/images/hearder.jpg');
  background-size: cover;
  background-position: center;
}
</style>