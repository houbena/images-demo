pipeline {    

    agent any    

    environment {
        DTR_FQDN='ec2-18-197-157-17.eu-central-1.compute.amazonaws.com:4443'
    }

    stages {
        stage('Build') {
            steps {
                sh 'docker image build \
                    -t ${DTR_FQDN}/jenkins/myapp:build-${BUILD_ID} .'
                sh 'docker image build \
                    --target testrunner -t myapp:testbuild-${BUILD_ID} .'
            }
        }
        stage('Test') {
            steps {
                sh 'docker container run myapp:testbuild-${BUILD_ID}'
            }
        }
        stage('Push') {
            environment {
                DTR_ACCESS_KEY = credentials('jenkins-dtr-access-token')
            }
            steps {
                sh 'docker login -u jenkins -p ${DTR_ACCESS_KEY} ${DTR_FQDN} ; \
                    docker image push ${DTR_FQDN}/jenkins/myapp:build-${BUILD_ID}'
            }
        }
    }
}
