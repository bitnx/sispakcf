<!doctype html>
<html lang="en">

<head>

    <?= $title_meta ?>

    <?= $this->include('partials/head-css') ?>

</head>

<?= $this->include('partials/body') ?>

<!-- <body data-layout="horizontal"> -->

<!-- Begin page -->
<div id="layout-wrapper">

    <?= $this->include('partials/menu') ?>

    <!-- ============================================================== -->
    <!-- Start right Content here -->
    <!-- ============================================================== -->
    <div class="main-content">

        <div class="page-content">
            <div class="container-fluid">

                <!-- start page title -->
                <?= $page_title ?>
                <!-- end page title -->

                <div class="row">
                    <div class="flex">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-sm order-2 order-sm-1">
                                        <div class="d-flex align-items-start mt-3 mt-sm-0">
                                            <div class="flex-shrink-0">
                                                <div class="avatar-xl me-3">
                                                    <img src="assets/images/users/avatar-1.jpg" alt=""
                                                        class="img-fluid rounded-circle d-block">
                                                </div>
                                            </div>
                                            <div class="flex-grow-1">
                                                <div>
                                                    <h5 class="font-size-16 mb-1">ADMIN</h5>
                                                    <p class="text-muted font-size-13">Full Stack Developer</p>

                                                    <div
                                                        class="d-flex flex-wrap align-items-start gap-2 gap-lg-3 text-muted font-size-13">
                                                        <div><i
                                                                class="mdi mdi-circle-medium me-1 text-success align-middle"></i>Development
                                                        </div>
                                                        <div><i
                                                                class="mdi mdi-circle-medium me-1 text-success align-middle"></i>admin@ganteng.com
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                            </div>
                            <!-- end card body -->
                        </div>
                        <!-- end card -->

                        <div class="tab-content">
                            <div class="tab-pane active" id="overview" role="tabpanel">
                                <div class="card">
                                    <div class="card-header">
                                        <h5 class="card-title mb-0">Overview</h5>
                                    </div>
                                    <div class="card-body">
                                        <div>
                                            <div class="pb-3">
                                                <div class="row">
                                                    <div class="col-xl-2">
                                                        <div>
                                                            <h5 class="font-size-15">Bio :</h5>
                                                        </div>
                                                    </div>
                                                    <div class="col-xl">
                                                        <div class="text-muted">
                                                            <p class="mb-2">Lorem ipsum dolor sit amet consectetur
                                                                adipisicing elit. Maiores doloremque quos harum placeat
                                                                ratione culpa velit iste, corporis fugit adipisci eos
                                                                dolore ut, cupiditate ad, quasi explicabo totam
                                                                voluptatem quisquam.</p>
                                                            <p class="mb-0">YESSIR</p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="py-3">
                                                <div class="row">
                                                    <div class="col-xl-2">
                                                        <div>
                                                            <h5 class="font-size-15">Experience :</h5>
                                                        </div>
                                                    </div>
                                                    <div class="col-xl">
                                                        <div class="text-muted">
                                                            <p>If several languages coalesce, the grammar of the
                                                                resulting language is more simple and regular than that
                                                                of the individual languages. The new common language
                                                                will be more simple and regular than the existing
                                                                European languages. It will be as simple as Occidental;
                                                                in fact, it will be Occidental. To an English person, it
                                                                will seem like simplified English, as a skeptical
                                                                Cambridge friend of mine told me what Occidental is. The
                                                                European languages are members of the same family. Their
                                                                separate existence is a myth. For science, music, sport,
                                                                etc</p>

                                                            <ul class="list-unstyled mb-0">
                                                                <li class="py-1"><i
                                                                        class="mdi mdi-circle-medium me-1 text-success align-middle"></i>Donec
                                                                    vitae sapien ut libero venenatis faucibus</li>
                                                                <li class="py-1"><i
                                                                        class="mdi mdi-circle-medium me-1 text-success align-middle"></i>Quisque
                                                                    rutrum aenean imperdiet</li>
                                                                <li class="py-1"><i
                                                                        class="mdi mdi-circle-medium me-1 text-success align-middle"></i>Integer
                                                                    ante a consectetuer eget</li>
                                                                <li class="py-1"><i
                                                                        class="mdi mdi-circle-medium me-1 text-success align-middle"></i>Phasellus
                                                                    nec sem in justo pellentesque</li>
                                                            </ul>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- end card body -->
                                </div>
                                <!-- end card -->


                            </div>
                            <!-- end card -->
                        </div>
                        <!-- end tab pane -->

                        <div class="tab-pane" id="about" role="tabpanel">
                            <div class="card">
                                <div class="card-header">
                                    <h5 class="card-title mb-0">About</h5>
                                </div>
                                <div class="card-body">
                                    <div>
                                        <div class="pb-3">
                                            <h5 class="font-size-15">Bio :</h5>
                                            <div class="text-muted">
                                                <p class="mb-2">Hi I'm Phyllis Gatlin, Lorem Ipsum is simply dummy text
                                                    of the printing and typesetting industry. Lorem Ipsum has been the
                                                    industry's standard dummy text ever since the 1500s, when an unknown
                                                    printer took a galley of type and scrambled it to make a type
                                                    specimen book. It has survived not only five centuries, but also the
                                                    leap into electronic typesetting, remaining essentially unchanged.
                                                    It was popularised in the 1960s with the release of Letraset sheets
                                                    containing Lorem Ipsum passages</p>
                                                <p class="mb-2">It is a long established fact that a reader will be
                                                    distracted by the readable content of a page when looking at it has
                                                    a more-or-less normal distribution of letters</p>
                                                <p>It will be as simple as Occidental; in fact, it will be Occidental.
                                                    To an English person, it will seem like simplified English, as a
                                                    skeptical Cambridge friend of mine told me what Occidental is. The
                                                    European languages are members of the same family. Their separate
                                                    existence is a myth.</p>

                                                <ul class="list-unstyled mb-0">
                                                    <li class="py-1"><i
                                                            class="mdi mdi-circle-medium me-1 text-success align-middle"></i>Donec
                                                        vitae sapien ut libero venenatis faucibus</li>
                                                    <li class="py-1"><i
                                                            class="mdi mdi-circle-medium me-1 text-success align-middle"></i>Quisque
                                                        rutrum aenean imperdiet</li>
                                                    <li class="py-1"><i
                                                            class="mdi mdi-circle-medium me-1 text-success align-middle"></i>Integer
                                                        ante a consectetuer eget</li>
                                                </ul>
                                            </div>
                                        </div>

                                        <div class="pt-3">
                                            <h5 class="font-size-15">Experience :</h5>
                                            <div class="text-muted">
                                                <p>If several languages coalesce, the grammar of the resulting language
                                                    is more simple and regular than that of the individual languages.
                                                    The new common language will be more simple and regular than the
                                                    existing European languages. It will be as simple as Occidental; in
                                                    fact, it will be Occidental. To an English person, it will seem like
                                                    simplified English, as a skeptical Cambridge friend of mine told me
                                                    what Occidental is. The European languages are members of the same
                                                    family. Their separate existence is a myth. For science, music,
                                                    sport, etc</p>

                                                <ul class="list-unstyled mb-0">
                                                    <li class="py-1"><i
                                                            class="mdi mdi-circle-medium me-1 text-success align-middle"></i>Donec
                                                        vitae sapien ut libero venenatis faucibus</li>
                                                    <li class="py-1"><i
                                                            class="mdi mdi-circle-medium me-1 text-success align-middle"></i>Quisque
                                                        rutrum aenean imperdiet</li>
                                                    <li class="py-1"><i
                                                            class="mdi mdi-circle-medium me-1 text-success align-middle"></i>Integer
                                                        ante a consectetuer eget</li>
                                                    <li class="py-1"><i
                                                            class="mdi mdi-circle-medium me-1 text-success align-middle"></i>Phasellus
                                                        nec sem in justo pellentesque</li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- end card body -->
                            </div>
                            <!-- end card -->
                        </div>
                        <!-- end tab pane -->


                    </div>
                    <!-- end tab pane -->
                </div>
                <!-- end tab content -->
            </div>
            <!-- end col -->


        </div>
        <!-- end col -->
    </div>
    <!-- end row -->

</div> <!-- container-fluid -->
</div>
<!-- End Page-content -->


<?= $this->include('partials/footer') ?>
</div>
<!-- end main content-->

</div>
<!-- END layout-wrapper -->


<?= $this->include('partials/right-sidebar') ?>

<!-- JAVASCRIPT -->
<?= $this->include('partials/vendor-scripts') ?>

<script src="assets/js/app.js"></script>

</body>

</html>